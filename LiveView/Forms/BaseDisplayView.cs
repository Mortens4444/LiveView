using LiveView.Core.Dto;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Dto;
using LiveView.Enums;
using LiveView.Interfaces;
using LiveView.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class BaseDisplayView : BaseView, IBaseDisplayView
    {
        private static Font font;

        private Timer mouseUpdateTimer;
        private IDisplayPresenter displayPresenter;
        private static readonly Regex ButtonNameRegex = new Regex(@"btnCloseSequence(\d+)OnDisplay(\d+)", RegexOptions.Compiled);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<DisplayDto> CachedDisplays { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, Rectangle> CachedBounds { get; private set; }

        static BaseDisplayView()
        {
            font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        }

        public BaseDisplayView() : this(null, typeof(BasePresenter))
        {
        }

        public BaseDisplayView(IServiceProvider serviceProvider, Type presenterType) : base(serviceProvider, presenterType)
        {
        }

        public void InitializeMouseUpdateTimer(Panel panel)
        {
            mouseUpdateTimer = new Timer
            {
                Interval = 100
            };
            mouseUpdateTimer.Tick += (s, e) => panel.Invalidate();
            mouseUpdateTimer.Start();
        }

        protected void DrawMouse(Graphics graphics, Size size)
        {
            displayPresenter = (IDisplayPresenter)Presenter;
            var mouseLocation = displayPresenter.GetMouseLocation(size);

            using (var redBrush = new SolidBrush(Color.Red))
            {
                graphics.FillEllipse(redBrush, mouseLocation.X, mouseLocation.Y, 3, 3);
            }
        }

        protected void DrawDisplays(Panel panel, Graphics graphics, DisplayDrawingTools displayDrawingTools, bool showSeqences)
        {
            if (CachedDisplays == null)
            {
                return;
            }

            var groupedByHost = CachedDisplays
                .GroupBy(d => d.Host)
                .OrderBy(g => g.Key);

            foreach (var group in groupedByHost)
            {
                foreach (var display in group)
                {
                    DrawDisplay(panel, graphics, display, displayDrawingTools, showSeqences);
                    if (displayDrawingTools == DisplayDrawingTools.Selected && display.Selected)
                    {
                        var sequenceProcess = Globals.SequenceProcesses.FirstOrDefault(sp => sp.Value.GetDisplayId() == display.Id);
                        ShowSequenceProcessData(sequenceProcess.Value);
                    }
                }
            }
        }

        protected virtual void ShowSequenceProcessData(SequenceProcessInfo sequenceProcess) { }

        protected void GetAndCacheDisplays(Size size)
        {
            if (CachedDisplays == null || CachedBounds == null)
            {
                displayPresenter = (IDisplayPresenter)Presenter;
                CachedDisplays = displayPresenter.GetDisplays();
                CachedBounds = displayPresenter.GetScaledDisplayBounds(CachedDisplays, size);
            }
        }

        private void DrawDisplay(Panel panel, Graphics graphics, DisplayDto display, DisplayDrawingTools displayDrawingTools, bool showSeqences)
        {
            if (!(CachedBounds?.TryGetValue(display.Id, out var bounds) ?? false))
            {
                return;
            }

            var (drawingPen, drawingBrush) = displayPresenter.GetDrawingTools(display, displayDrawingTools);
            Draw(panel, graphics, display, bounds, drawingPen, drawingBrush, showSeqences);
        }

        private static Rectangle GetAdjustedBounds(Rectangle bounds)
        {
            return new Rectangle(
                bounds.Left + DisplayManager.FrameWidth,
                bounds.Top + DisplayManager.FrameWidth,
                bounds.Width - 2 * DisplayManager.FrameWidth,
                bounds.Height - 2 * DisplayManager.FrameWidth
            );
        }

        private void Draw(Panel panel, Graphics graphics, DisplayDto display, Rectangle bounds, Pen drawingPen, SolidBrush drawingBrush, bool showSeqences)
        {
            graphics.DrawRectangle(drawingPen, bounds);
            graphics.FillRegion(drawingBrush, new Region(bounds));
            var adjustedBounds = GetAdjustedBounds(bounds);
            graphics.DrawRectangle(drawingPen, adjustedBounds);

            if (showSeqences)
            {
                ShowSequence(panel, graphics, display, adjustedBounds);
            }
            ShowDisplayName(graphics, display, adjustedBounds);
        }

        private static void ShowDisplayName(Graphics graphics, DisplayDto display, Rectangle adjustedBounds)
        {
            var displayName = display.SziltechId;
            using (var drawBrush = new SolidBrush(Color.Black))
            {
                var labelSize = graphics.MeasureString(displayName, font);
                graphics.DrawString(displayName, font, drawBrush,
                    adjustedBounds.Left + (adjustedBounds.Width - labelSize.Width) / 2,
                    adjustedBounds.Top + (adjustedBounds.Height - labelSize.Height) / 2
                );
            }
        }

        private const int delta = 4;

        private void ShowSequence(Panel panel, Graphics graphics, DisplayDto display, Rectangle adjustedBounds)
        {
            var sequenceEnvironments = displayPresenter.GetSequenceEnvironments(display);
            foreach (var sequenceEnvironment in sequenceEnvironments)
            {
                var (drawingPen, sequenceBrush) = displayPresenter.GetDrawingTools(display, DisplayDrawingTools.Sequence);
                graphics.FillRectangle(sequenceBrush, adjustedBounds);

                var location = new Point(adjustedBounds.Right - sequenceEnvironment.CloseButton.Width - delta, adjustedBounds.Top + delta);
                if (!panel.Controls.Contains(sequenceEnvironment.CloseButton))
                {
                    panel.Controls.Add(sequenceEnvironment.CloseButton);
                }
                sequenceEnvironment.CloseButton.Location = location;
                sequenceEnvironment.CloseButton.Refresh();
            }
            RemoveInvalidButtons(panel, display);
        }

        private static void RemoveInvalidButtons(Panel panel, DisplayDto display)
        {
            foreach (var control in panel.Controls)
            {
                if (control is Button button && ButtonNameRegex.IsMatch(button.Name))
                {
                    var match = ButtonNameRegex.Match(button.Name);
                    if (match.Success && Int64.TryParse(match.Groups[1].Value, out long sequenceId))
                    {
                        var sequenceProcessInfoList = Globals.SequenceProcesses.Values;
                        if (!(sequenceProcessInfoList.Any(sequenceProcessInfo => sequenceProcessInfo.SequenceId == sequenceId
                            && sequenceProcessInfo.GetDisplayId() == match.Groups[2].Value)))
                        {
                            button.SafeDispose();
                        }
                    }
                }
            }
        }
    }
}