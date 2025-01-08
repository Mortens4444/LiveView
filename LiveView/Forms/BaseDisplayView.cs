using LiveView.Core.Dto;
using LiveView.Core.Services;
using LiveView.Enums;
using LiveView.Interfaces;
using LiveView.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class BaseDisplayView : BaseView, IBaseDisplayView
    {
        private static Font font;

        private Timer mouseUpdateTimer;
        private IDisplayPresenter displayPresenter;

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

        protected void DrawDisplays(Graphics graphics, DisplayDrawingTools displayDrawingTools, string hostname)
        {
            if (CachedDisplays == null)
            {
                return;
            }

            foreach (var display in CachedDisplays)
            {
                if (display.Host == hostname)
                {
                    DrawDisplay(graphics, display, displayDrawingTools);
                }
            }
        }

        protected void GetAndCacheDisplays(Size size)
        {
            if (CachedDisplays == null || CachedBounds == null)
            {
                displayPresenter = (IDisplayPresenter)Presenter;
                CachedDisplays = displayPresenter.GetDisplays();
                CachedBounds = displayPresenter.GetScaledDisplayBounds(CachedDisplays, size);
            }
        }

        private void DrawDisplay(Graphics graphics, DisplayDto display, DisplayDrawingTools displayDrawingTools)
        {
            if (!CachedBounds.TryGetValue(display.Id, out var bounds))
            {
                return;
            }

            var adjustedBounds = GetAdjustedBounds(bounds);
            var (drawingPen, drawingBrush) = displayPresenter.GetDrawingTools(display, displayDrawingTools);
            Draw(graphics, display, bounds, adjustedBounds, drawingPen, drawingBrush);
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

        private void Draw(Graphics graphics, DisplayDto display, Rectangle bounds, Rectangle adjustedBounds, Pen drawingPen, SolidBrush drawingBrush)
        {
            graphics.DrawRectangle(drawingPen, bounds);
            graphics.FillRegion(drawingBrush, new Region(bounds));
            graphics.DrawRectangle(drawingPen, adjustedBounds);

            ShowSeqence(graphics, display, adjustedBounds);
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

        private void ShowSeqence(Graphics graphics, DisplayDto display, Rectangle adjustedBounds)
        {
            try
            {
                var starters = displayPresenter.GetSequenceEnvironments();
                foreach (var starter in starters)
                {
                    if (starter.Display.Id == display.Id)
                    {
                        var (drawingPen, sequenceBrush) = displayPresenter.GetDrawingTools(display, DisplayDrawingTools.Sequence);
                        graphics.FillRectangle(sequenceBrush, adjustedBounds);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //DebugErrorBox.Show(ex);
            }
        }
    }
}