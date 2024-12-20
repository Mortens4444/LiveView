using LiveView.Dto;
using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class BaseDisplayView : BaseView, IView
    {
        private static Pen blackPen, bluePen;
        private static Font font;
        private static SolidBrush lbBrush, bcBrush, gcBrush, lgcBrush, mouseBrush;

        private readonly DisplayManager displayManager;

        private List<DisplayDto> cachedDisplays;
        private Dictionary<int, Rectangle> cachedBounds;
        private Timer mouseUpdateTimer;
        private IDisplayPresenter displayPresenter;

        static BaseDisplayView()
        {
            blackPen = new Pen(Color.Black, 2);
            bluePen = new Pen(Color.Blue, 2);
            font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            lbBrush = new SolidBrush(Color.CornflowerBlue);
            bcBrush = new SolidBrush(Color.LightBlue);
            gcBrush = new SolidBrush(Color.Gray);
            lgcBrush = new SolidBrush(Color.LightGreen);
            mouseBrush = new SolidBrush(Color.Red);
        }

        public BaseDisplayView() : this(new DisplayManager(), new PermissionManager())
        {
        }

        public BaseDisplayView(DisplayManager displayManager, PermissionManager permissionManager) : base(permissionManager)
        {
        }

        protected new void SetPresenter(BasePresenter presenter)
        {
            base.SetPresenter(presenter);
            displayPresenter = presenter as IDisplayPresenter;
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
            var mouseLocation = displayPresenter.GetMouseLocation(size);
            graphics.FillEllipse(mouseBrush, mouseLocation.X, mouseLocation.Y, 3, 3);
        }

        protected void DrawDisplays(Graphics graphics)
        {
            foreach (var display in cachedDisplays)
            {
                DrawDisplay(graphics, display);
            }
        }

        protected void GetAndCacheDisplays(Panel panel)
        {
            if (cachedDisplays == null || cachedBounds == null)
            {
                cachedDisplays = displayPresenter.GetDisplays();
                cachedBounds = displayPresenter.GetScaledDisplayBounds(cachedDisplays, panel.Size);
            }
        }

        private void DrawDisplay(Graphics graphics, DisplayDto display)
        {
            if (!cachedBounds.TryGetValue(display.Id, out var bounds))
            {
                return;
            }

            var adjustedBounds = new Rectangle(
                bounds.Left + DisplayManager.FrameWidth,
                bounds.Top + DisplayManager.FrameWidth,
                bounds.Width - 2 * DisplayManager.FrameWidth,
                bounds.Height - 2 * DisplayManager.FrameWidth
            );

            var drawingPen = display.Selected ? bluePen : blackPen;
            var drawingBrush = display.Selected ? lbBrush : bcBrush;

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
                        var sequenceBrush = display.Selected ? lgcBrush : gcBrush;
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