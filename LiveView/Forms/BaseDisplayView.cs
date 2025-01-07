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
        private static Pen blackPen, bluePen;
        private static SolidBrush cornflowerBlueBrush, lightBlueBrush, grayBrush, lightGreenBrush, redBrush, lightGoldenrodYellowBrush;

        private Timer mouseUpdateTimer;
        private IDisplayPresenter displayPresenter;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<DisplayDto> CachedDisplays { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, Rectangle> CachedBounds { get; private set; }

        static BaseDisplayView()
        {
            blackPen = new Pen(Color.Black, 2);
            bluePen = new Pen(Color.Blue, 2);
            font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            cornflowerBlueBrush = new SolidBrush(Color.CornflowerBlue);
            lightBlueBrush = new SolidBrush(Color.LightBlue);
            grayBrush = new SolidBrush(Color.Gray);
            lightGreenBrush = new SolidBrush(Color.LightGreen);
            lightGoldenrodYellowBrush = new SolidBrush(Color.LightGoldenrodYellow);
            redBrush = new SolidBrush(Color.Red);
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
            graphics.FillEllipse(redBrush, mouseLocation.X, mouseLocation.Y, 3, 3);
        }

        protected void DrawDisplays(Graphics graphics, DisplayDrawingTools displayDrawingTools)
        {
            foreach (var display in CachedDisplays)
            {
                DrawDisplay(graphics, display, displayDrawingTools);
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
            var (drawingPen, drawingBrush) = GetDrawingTools(display, displayDrawingTools);
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

        private (Pen, SolidBrush) GetDrawingTools(DisplayDto display, DisplayDrawingTools displayDrawingTools)
        {
            if (displayDrawingTools == DisplayDrawingTools.Functions)
            {
                if (display.CanShowSequence && display.CanShowFullscreen)
                {
                    return (blackPen, lightBlueBrush);
                }
                else if (display.CanShowSequence)
                {
                    return (blackPen, lightGoldenrodYellowBrush);
                }
                else if (display.CanShowFullscreen)
                {
                    return (blackPen, lightGreenBrush);
                }

                return (blackPen, grayBrush);
            }

            if (displayDrawingTools == DisplayDrawingTools.Selected)
            {
                if (display.Selected)
                {
                    return (bluePen, cornflowerBlueBrush);
                }

                return (blackPen, lightBlueBrush);
            }

            if (displayDrawingTools == DisplayDrawingTools.Fullscreen)
            {
                if (display.Fullscreen)
                {
                    return (blackPen, lightGreenBrush);
                }
                return (blackPen, lightBlueBrush);
            }

            throw new NotImplementedException($"Display drawing tools ({displayDrawingTools}) are not implemented.");
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
                        var sequenceBrush = display.Selected ? lightGreenBrush : grayBrush;
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