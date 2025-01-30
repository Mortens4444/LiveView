using LiveView.Core.Dto;
using LiveView.Core.Services;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls;
using Mtf.HardwareKey;
using Mtf.HardwareKey.Extensions;
using Mtf.HardwareKey.Interfaces;
using Mtf.Joystick;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class MainForm : BaseView, IMainView
    {
        private MainPresenter presenter;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static string Uptime { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static string SystemUptime { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static string Day { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static string Days { get; set; }

        public static readonly ISltHardwareKey HardwareKey;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ControlCenter ControlCenter { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static DisplayDto FullScreenDisplay { get; set; }

        public ToolStripStatusLabel TsslServerData => tsslServerData;

        public MtfPictureBox PbMap => pbMap;

        public ToolTip TtHint => ttHint;

        public TextBox TbUsername => tbUsername;

        public PasswordBox TbPassword => tbPassword;

        public Label LblPassword => lblPassword;

        public GroupBox GbPrimaryLogon => gbPrimaryLogon;

        public Button BtnLoginLogoutPrimary => btnLoginLogoutPrimary;

        static MainForm()
        {
            HardwareKey = new VirtualSziltechHardwareKey();
            //HardwareKey = new SziltechHardwareKey();
            HardwareKey.GetDescription();

            JoystickHandler.InitializeJoystick(
                continuePulling: () => true,
                getDeltaModifier: () => 10,
                getMinimumDelta: () => 5,
                restAction: (deltaX, deltaY) => Console.WriteLine("Joystick at rest."),
                forwardOrBackwardAction: (deltaX, deltaY) => Console.WriteLine($"Moving forward/backward: {deltaY}"),
                forwardWithLeftTurnAction: (deltaX, deltaY) => Console.WriteLine($"Forward with left turn: {deltaX}, {deltaY}"),
                forwardWithRightTurnAction: (deltaX, deltaY) => Console.WriteLine($"Forward with right turn: {deltaX}, {deltaY}"),
                backwardWithLeftTurnAction: (deltaX, deltaY) => Console.WriteLine($"Backward with left turn: {deltaX}, {deltaY}"),
                backwardWithRightTurnAction: (deltaX, deltaY) => Console.WriteLine($"Backward with right turn: {deltaX}, {deltaY}"),
                turnLeftOrRightAction: (deltaX, deltaY) => Console.WriteLine($"Turning left/right: {deltaX}"),
                afterPullingAction: () => Console.WriteLine("Polling stopped."),
                buttonActions: new Action[]
                {
                    () => Console.WriteLine("Button 1 pressed."),
                    () => Console.WriteLine("Button 2 pressed."),
                    () => Console.WriteLine("Button 3 pressed."),
                }
            );
        }

        public MainForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(MainPresenter))
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as MainPresenter;
            presenter.Load();
            presenter.AutoLogin();
        }

        private void TsmiControlCenter_Click(object sender, EventArgs e)
        {
            if (ControlCenter == null || ControlCenter.IsDisposed)
            {
                ControlCenter = presenter.ShowForm<ControlCenter>();
            }
            else
            {
                ControlCenter.Close();
                ControlCenter.Dispose();
                ControlCenter = null;
            }
        }

        [RequirePermission(ServerManagementPermissions.FullControl)]
        [RequirePermission(CameraManagementPermissions.FullControl)]
        private void TsmiServerAndCameraManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<ServerAndCameraManagement>();
        }

        [RequirePermission(GridManagementPermissions.FullControl)]
        private void TsmiGridManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<GridManager>();
        }

        [RequirePermission(SequenceManagementPermissions.FullControl)]
        private void TsmiSequentialChains_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<SequentialChains>();
        }

        [RequirePermission(GridManagementPermissions.FullControl)]
        [RequirePermission(SequenceManagementPermissions.FullControl)]
        [RequirePermission(TemplateManagementPermissions.FullControl)]
        private void TsmiAutoCreateWizard_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<AutoCreateWizard>();
        }

        [RequirePermission(TemplateManagementPermissions.FullControl)]
        private void TsmiTemplates_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<Templates>();
        }

        [RequirePermission(UserManagementPermissions.FullControl)]
        [RequirePermission(GroupManagementPermissions.FullControl)]
        private void TsmiUserAndGroupManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<UserAndGroupManagement>();
        }

        [RequirePermission(UserManagementPermissions.FullControl)]
        private void TsmiProfile_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<Profile>();
        }

        [RequirePermission(SettingsManagementPermissions.PersonalSettingsManagement)]

        private void TsmiPersonalOptions_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<PersonalOptionsForm>();
        }

        [RequirePermission(SettingsManagementPermissions.StaticSettingsManagement)]
        private void TsmiGeneralOptions_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<GeneralOptionsForm>();
        }

        [RequirePermission(DisplayManagementPermissions.FullControl)]
        private void TsmiDisplaySettings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<DisplaySettings>();
        }

        [RequirePermission(LanguageManagementPermissions.Update)]
        private void TsmiLanguageEditor_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            AppStarter.Start(Path.Combine(Application.StartupPath, "Languages.ods"));
        }

        [RequirePermission(LogManagementPermissions.Select)]
        private void TsmiLogViewer_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<LogViewer>();
        }

        private void TsmiPositioningMousePointer_Click(object sender, EventArgs e)
        {
            MainPresenter.MoveMouseToHome();
        }

        [RequirePermission(SerialDeviceManagementPermissions.FullControl)]
        private void TsmiBarCodeReadings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<BarcodeReadings>();
        }

        [RequirePermission(CameraManagementPermissions.FullControl)]
        private void TsmiSyncronView_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<SyncronView>();
        }

        [RequirePermission(IODeviceManagementPermissions.FullControl)]
        private void TsmiIOPortsSettings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<IOPortSettings>();
        }

        [RequirePermission(CameraManagementPermissions.FullControl)]
        private void TsmiMotionPopup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<CameraMotionSettings>();
        }

        [RequirePermission(MapManagementPermissions.FullControl)]
        private void TsmiMapCreator_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            _ = presenter.ShowFormWithCloseAction<MapCreator>(() => presenter.LoadFirstMap());
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            presenter.ShowForm<About>();
        }

        private void TsmiLicense_Click(object sender, EventArgs e)
        {
            presenter.ShowForm<LicenseForm>();
        }

        [RequirePermission(CameraManagementPermissions.OpenFullScreen)]
        [RequirePermission(CameraManagementPermissions.PTZ)]
        private void TsmiKBD300ASimulator_Click(object sender, EventArgs e)
        {
            presenter.ShowForm<KBD300ASimulator>();
        }

        [RequirePermission(ApplicationManagementPermissions.Exit)]
        private void TsmiExit_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Exit();
        }

        private void BtnLoginLogoutPrimary_Click(object sender, EventArgs e)
        {
            if (permissionManager.CurrentUser == null)
            {
                presenter.Login();
            }
            else
            {
                presenter.Logout();
            }
        }

        public IntPtr GetHandle()
        {
            return Handle;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    HandleHotkey(m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void HandleHotkey(Message m)
        {
            switch (m.WParam.ToInt32())
            {
                case 1:
                    presenter?.SetCursorPosition();
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public void SetCursorPosition()
        {
            if (ControlCenter != null)
            {
                Cursor.Position = ControlCenter.HomeLocation;
                WinAPI.SetCursorPos(ControlCenter.HomeLocation.X, ControlCenter.HomeLocation.Y);
            }
            else
            {
                var point = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
                Cursor.Position = point;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            presenter?.SetUptime();
        }

        public void SetUptime(TimeSpan osUptime, TimeSpan appUptime)
        {
            tsslOsUptime.Text = osUptime.Days < 2 ? $"{SystemUptime}: {osUptime.Days} {Day} {osUptime.Hours:D2}:{osUptime.Minutes:D2}:{osUptime.Seconds:D2}" : $"{Uptime}: {osUptime.Days} {Days} {osUptime.Hours:D2}:{appUptime.Minutes:D2}:{osUptime.Seconds:D2}";
            tsslUptime.Text = appUptime.Days < 2 ? $"{Uptime}: {appUptime.Days} {Day} {appUptime.Hours:D2}:{appUptime.Minutes:D2}:{appUptime.Seconds:D2}" : $"{Uptime}: {appUptime.Days} {Days} {appUptime.Hours:D2}:{appUptime.Minutes:D2}:{appUptime.Seconds:D2}";
        }

        [RequirePermission(ApplicationManagementPermissions.Exit)]
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            permissionManager.EnsurePermissions();
            if (!presenter.Exit())
            {
                e.Cancel = true;
            }
            // This point is never reached - Do all exit login in the Exit function!!!
        }
    }
}
