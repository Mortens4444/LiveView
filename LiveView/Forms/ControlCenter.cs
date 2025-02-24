using Database.Enums;
using Database.Models;
using LiveView.Dto;
using LiveView.Enums;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ControlCenter : BaseDisplayView, IControlCenterView
    {
        private readonly Camera camera;
        private readonly VideoSourceDto videoSource;
        private readonly ManualResetEvent initializationCompleted = new ManualResetEvent(false);

        private ControlCenterPresenter presenter;

        public Label LblSequenceName => lblSequenceName;

        public Label LblNumberOfCameras => lblNumberOfCameras;

        public Label LblGridName => lblGridName;

        public Label LblGridNumber => lblGridNumber;

        public Label LblSecondsLeft => lblSecondsLeft;

        public ControlCenter(IServiceProvider serviceProvider, Camera camera = null, VideoSourceDto videoSource = null) : this(serviceProvider)
        {
            this.camera = camera;
            this.videoSource = videoSource;
        }

        private ControlCenter(IServiceProvider serviceProvider) : base(serviceProvider, typeof(ControlCenterPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        public void SetImagesEnabledState()
        {
            var panTilt = permissionManager.CurrentUser?.HasPermission(CameraManagementPermissions.PanTilt) ?? false;
            if (!panTilt)
            {
                btnMoveCameraNorthWest.Image = Properties.Resources.nw_g;
                btnMoveCameraNorthEast.Image = Properties.Resources.ne_g;
                btnMoveCameraSouthWest.Image = Properties.Resources.sw_g;
                btnMoveCameraSouthEast.Image = Properties.Resources.se_g;
                btnMoveCameraToPresetZero.Image = Properties.Resources.house_g;
            }
            else
            {
                btnMoveCameraNorthWest.Image = Properties.Resources.nw;
                btnMoveCameraNorthEast.Image = Properties.Resources.ne;
                btnMoveCameraSouthWest.Image = Properties.Resources.sw;
                btnMoveCameraSouthEast.Image = Properties.Resources.se;
                btnMoveCameraToPresetZero.Image = Properties.Resources.house;
            }
            btnMoveCameraNorthWest.Enabled = panTilt;
            btnMoveCameraNorthEast.Enabled = panTilt;
            btnMoveCameraSouthWest.Enabled = panTilt;
            btnMoveCameraSouthEast.Enabled = panTilt;
            btnMoveCameraToPresetZero.Enabled = panTilt;

            btnCloseSequenceApplications.Enabled = permissionManager.CurrentUser?.HasPermission(SequenceManagementPermissions.Close) ?? false;
            btnCloseFullScreenCamera.Enabled = permissionManager.CurrentUser?.HasPermission(CameraManagementPermissions.CloseFullScreen) ?? false;

            var pan = permissionManager.CurrentUser?.HasPermission(CameraManagementPermissions.Pan) ?? false;
            if (!pan)
            {
                btnMoveCameraEast.Image = Properties.Resources.e_g;
                btnMoveCameraWest.Image = Properties.Resources.w_g;
            }
            else
            {
                btnMoveCameraEast.Image = Properties.Resources.arrow_right;
                btnMoveCameraWest.Image = Properties.Resources.arrow_left;
            }
            btnMoveCameraEast.Enabled = pan;
            btnMoveCameraWest.Enabled = pan;

            var tilt = permissionManager.CurrentUser?.HasPermission(CameraManagementPermissions.Tilt) ?? false;
            if (!tilt)
            {
                btnMoveCameraNorth.Image = Properties.Resources.n_g;
                btnMoveCameraSouth.Image = Properties.Resources.s_g;
            }
            else
            {
                btnMoveCameraNorth.Image = Properties.Resources.arrow_up;
                btnMoveCameraSouth.Image = Properties.Resources.arrow_down;
            }
            btnMoveCameraNorth.Enabled = tilt;
            btnMoveCameraSouth.Enabled = tilt;
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

        public Panel PDisplayDevices => pDisplayDevices;

        public ListView LvCameras => lvCameras;

        public ListView LvSequences => lvSequences;

        public ListView LvTemplates => lvTemplates;

        public ComboBox CbAgents => cbAgents;

        private void ControlCenter_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as ControlCenterPresenter;
            initializationCompleted.Set();
            presenter.Load();
            presenter.StartCameraApp(camera, camera?.FullscreenMode ?? CameraMode.AxVideoPlayer);
            presenter.StartCameraApp(videoSource);
        }

        [RequirePermission(SequenceManagementPermissions.Close)]
        private void BtnCloseSequenceApplications_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CloseSequenceApplications();
        }

        [RequirePermission(CameraManagementPermissions.CloseFullScreen)]
        private void BtnCloseFullScreenCamera_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CloseFullScreenCameraApplication();
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void BtnIdentify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.IdentifyDisplays();
        }

        [RequirePermission(JoystickManagementPermissions.Calibrate)]
        private void BtnCalibrate_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            ControlCenterPresenter.CalibrateJoystick();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnShowPreviousGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowPreviousGrid();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnPlayOrPauseSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.PlayOrPauseSequence();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnShowNextGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowNextGrid();
        }

        [RequirePermission(GridManagementPermissions.Rearrange)]
        private void BtnRearrangeGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.RearrangeGrids();
        }

        [RequirePermission(CameraManagementPermissions.ZoomIn)]
        private void BtnZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ZoomIn();
        }

        private void BtnZoomIn_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopZoom();
        }

        [RequirePermission(CameraManagementPermissions.ZoomOut)]
        private void BtnZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ZoomOut();
        }

        private void BtnZoomOut_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopZoom();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraNorthWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToNorthWest();
        }

        private void BtnMoveCameraNorthWest_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Tilt)]
        private void BtnMoveCameraNorth_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToNorth();
        }

        private void BtnMoveCameraNorth_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraNorthEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToNorthEast();
        }

        private void BtnMoveCameraNorthEast_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Pan)]
        private void BtnMoveCameraWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToWest();
        }

        private void BtnMoveCameraWest_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Preset)]
        private void BtnMoveCameraToPresetZero_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToPresetZero();
        }

        [RequirePermission(CameraManagementPermissions.Pan)]
        private void BtnMoveCameraEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToEast();
        }

        private void BtnMoveCameraEast_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraSouthWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToSouthWest();
        }

        private void BtnMoveCameraSouthWest_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Tilt)]
        private void BtnMoveCameraSouth_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToSouth();
        }

        private void BtnMoveCameraSouth_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraSouthEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToSouthEast();
        }

        private void BtnMoveCameraSouthEast_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        private void PDisplayDevices_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (CachedDisplays == null)
                {
                    GetAndCacheDisplays(PDisplayDevices.Size);
                }

                DrawDisplays(PDisplayDevices, e.Graphics, DisplayDrawingTools.Selected, CbAgents.SelectedIndex == 0 ? null : CbAgents.Text, true);
                DrawMouse(e.Graphics, PDisplayDevices.Size);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void LvSequences_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && e.Item.Tag is Database.Models.Sequence sequence)
            {
                if (presenter.StartSequenceApp(sequence))
                {
                    Thread.Sleep(1000);
                    e.Item.Selected = false;
                }
            }
        }

        private void LvCameras_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && e.Item.Tag is Camera camera)
            {
                if (presenter.StartCameraApp(camera, camera?.FullscreenMode ?? CameraMode.AxVideoPlayer))
                {
                    Thread.Sleep(1000);
                    e.Item.Selected = false;
                }
            }
            else if (e.IsSelected && e.Item.Tag is VideoSourceDto videoSource)
            {
                if (presenter.StartCameraApp(videoSource))
                {
                    Thread.Sleep(1000);
                    e.Item.Selected = false;
                }
            }
        }

        public void StartCamera(Camera camera)
        {
            presenter.StartCameraApp(camera, camera?.FullscreenMode ?? CameraMode.AxVideoPlayer);
        }

        public void StartVideoSource(VideoSourceDto videoSource)
        {
            presenter.StartCameraApp(videoSource);
        }

        private void PDisplayDevices_MouseClick(object sender, MouseEventArgs e)
        {
            presenter.SelectDisplay(e.Location);
        }

        public void RefreshAgents()
        {
            presenter.RefreshAgents();
        }

        private void ControlCenter_Load(object sender, EventArgs e)
        {
            pbSziltechLogo.BackColor = Color.WhiteSmoke;
        }

        private async void LvTemplates_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && e.Item.Tag is Template template)
            {
                presenter.StartTemplate(template);
                await Task.Delay(1000);
                e.Item.Selected = false;
            }
        }

        public void StartTemplate(Template template)
        {
            Task.Run(() =>
            {
                initializationCompleted.WaitOne();
                presenter.StartTemplate(template);
            });
        }

        public void ShowGridInfo(long gridId, string secondsLeft)
        {
            presenter?.ShowGridInfo(gridId, secondsLeft);
        }

        protected override void ShowSequenceProcessData(SequenceProcessInfo sequenceProcess)
        {
            presenter.ShowSequenceProcessData(sequenceProcess);
        }

        private void ControlCenter_ResizeEnd(object sender, EventArgs e)
        {
            CachedDisplays = null;
        }
    }
}
