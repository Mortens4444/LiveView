using Database.Interfaces;
using Database.Models;
using LiveView.Dto;
using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace LiveView.Forms
{
    public partial class ControlCenter : BaseView, IControlCenterView
    {
        private static Pen blackPen, bluePen;
		private static Font font;
		private static SolidBrush lbBrush, bcBrush, gcBrush, lgcBrush, mouseBrush;

        private readonly ControlCenterPresenter controlCenterPresenter;
        private readonly PermissionManager permissionManager;

        private List<DisplayDto> cachedDisplays;
        private Dictionary<int, Rectangle> cachedBounds;
        private Timer mouseUpdateTimer;

        static ControlCenter()
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

        public ControlCenter(PermissionManager permissionManager, ILogger<ControlCenter> logger, ITemplateRepository<Template> templateRepository, IDisplayRepository<Display> displayRepository, ICameraRepository<Camera> cameraRepository, DisplayManager displayManager)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            controlCenterPresenter = new ControlCenterPresenter(this, templateRepository, displayRepository, cameraRepository, displayManager, logger);

            Translator.Translate(this);
        }

        public Point HomeLocation
        {
            get
            {
                if ((Location.X != -32000) && (Location.Y != -32000))
                {
                    return new Point(Location.X + pCrossHair.Location.X + pbCrossHair.Width / 2 + 5, Location.Y + pDisplays.Location.Y + pCrossHair.Location.Y + SystemInformation.CaptionHeight + pbCrossHair.Height / 2 + 3);
                }

                return new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            }
        }

        public void InitializeMouseUpdateTimer()
        {
            mouseUpdateTimer = new Timer
            {
                Interval = 100
            };
            mouseUpdateTimer.Tick += (s, e) => pDisplayDevices.Invalidate();
            mouseUpdateTimer.Start();
        }

        [RequirePermission(SequenceManagementPermissions.Close)]
        private void BtnCloseSequenceApplications_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.CloseSequenceApplications();
        }

        [RequirePermission(CameraManagementPermissions.CloseFullScreen)]
        private void BtnCloseFullScreenCamera_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.CloseFullScreenCameraApplication();
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void BtnIdentify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.IdentifyDisplays();
        }

        [RequirePermission(JoystickManagementPermissions.Calibrate)]
        private void BtnCalibrate_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.CalibrateJoystick();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnShowPreviousGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.ShowPreviousGrid();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnPlayOrPauseSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.PlayOrPauseSequence();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnShowNextGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.ShowNextGrid();
        }

        [RequirePermission(GridManagementPermissions.Rearrange)]
        private void BtnRearrangeGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.RearrangeGrids();
        }

        [RequirePermission(CameraManagementPermissions.ZoomIn)]
        private void BtnZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.ZoomIn();
        }

        private void BtnZoomIn_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopZoom();
        }

        [RequirePermission(CameraManagementPermissions.ZoomOut)]
        private void BtnZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.ZoomOut();
        }

        private void BtnZoomOut_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopZoom();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraNorthWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToNorthWest();
        }

        private void BtnMoveCameraNorthWest_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Tilt)]
        private void BtnMoveCameraNorth_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToNorth();
        }

        private void BtnMoveCameraNorth_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraNorthEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToNorthEast();
        }

        private void BtnMoveCameraNorthEast_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Pan)]
        private void BtnMoveCameraWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToWest();
        }

        private void BtnMoveCameraWest_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Preset)]
        private void BtnMoveCameraToPresetZero_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToPresetZero();
        }

        [RequirePermission(CameraManagementPermissions.Pan)]
        private void BtnMoveCameraEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToEast();
        }

        private void BtnMoveCameraEast_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraSouthWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToSouthWest();
        }

        private void BtnMoveCameraSouthWest_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Tilt)]
        private void BtnMoveCameraSouth_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToSouth();
        }

        private void BtnMoveCameraSouth_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraSouthEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToSouthEast();
        }

        private void BtnMoveCameraSouthEast_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        private void ControlCenter_Shown(object sender, EventArgs e)
        {
            controlCenterPresenter.Load();
        }

        private void PDisplayDevices_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                GetAndCacheDisplays();
                DrawDisplays(e.Graphics);
                DrawMouse(e.Graphics);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void DrawMouse(Graphics graphics)
        {
            var mouseLocation = controlCenterPresenter.GetMouseLocation(pDisplayDevices.Size);
            graphics.FillEllipse(mouseBrush, mouseLocation.X, mouseLocation.Y, 3, 3);
        }

        private void DrawDisplays(Graphics graphics)
        {
            foreach (var display in cachedDisplays)
            {
                DrawDisplay(graphics, display);
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

        private void GetAndCacheDisplays()
        {
            if (cachedDisplays == null || cachedBounds == null)
            {
                cachedDisplays = controlCenterPresenter.GetDisplays();
                cachedBounds = controlCenterPresenter.GetScaledDisplayBounds(cachedDisplays, pDisplayDevices.Size);
            }
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
                var starters = controlCenterPresenter.GetSequenceEnvironments();
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
