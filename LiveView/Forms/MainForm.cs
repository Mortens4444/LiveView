using Database.Models;
using LiveView.Core.Services;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls;
using Mtf.HardwareKey;
using Mtf.HardwareKey.Extensions;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class MainForm : BaseView, IMainView
    {
        private MainPresenter presenter;

        public ToolStripStatusLabel TsslServerData => tsslServerData;

        public ToolStripStatusLabel TsslJoystick => tsslJoystick;

        public MtfPictureBox PbMap => pbMap;

        public ToolTip TtHint => ttHint;

        public TextBox TbUsername => tbUsername;

        public PasswordBox TbPassword => tbPassword;

        public Label LblPassword => lblPassword;

        public GroupBox GbPrimaryLogon => gbPrimaryLogon;

        public Button BtnLoginLogoutPrimary => btnLoginLogoutPrimary;

        public ListView LvUserEvents => lvUserEvents;

        static MainForm()
        {
#if DEBUG
            Globals.HardwareKey = new VirtualSziltechHardwareKey();
#else
            Globals.HardwareKey = new SziltechHardwareKey();
#endif
            Globals.HardwareKey.GetDescription();
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
            presenter.AutoLoadTemplate();
            presenter.LoadKbd300A();
            presenter.StartWatchdog();
        }

        private void TsmiControlCenter_Click(object sender, EventArgs e)
        {
            if (Globals.ControlCenter == null || Globals.ControlCenter.IsDisposed)
            {
                Globals.ControlCenter = presenter.ShowForm<ControlCenter>();
            }
            else
            {
                Globals.ControlCenter.Close();
                Globals.ControlCenter.Dispose();
                Globals.ControlCenter = null;
            }
        }

        [RequirePermission(ServerManagementPermissions.Select | ServerManagementPermissions.Create | ServerManagementPermissions.Update | ServerManagementPermissions.Delete)]
        [RequirePermission(CameraManagementPermissions.Select | CameraManagementPermissions.Create | CameraManagementPermissions.Update | CameraManagementPermissions.Delete)]
        private void TsmiServerAndCameraManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<ServerAndCameraManagement>();
        }

        [RequirePermission(GridManagementPermissions.Select | GridManagementPermissions.Create | GridManagementPermissions.Update | GridManagementPermissions.Delete)]
        private void TsmiGridManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<GridManager>();
        }

        [RequirePermission(SequenceManagementPermissions.Select | SequenceManagementPermissions.Create | SequenceManagementPermissions.Update | SequenceManagementPermissions.Delete)]
        private void TsmiSequentialChains_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<SequentialChains>();
        }

        [RequirePermission(GridManagementPermissions.Create)]
        [RequirePermission(SequenceManagementPermissions.Create)]
        [RequirePermission(TemplateManagementPermissions.Create)]
        private void TsmiAutoCreateWizard_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<AutoCreateWizard>();
        }

        [RequirePermission(TemplateManagementPermissions.Select | TemplateManagementPermissions.Create | TemplateManagementPermissions.Update | TemplateManagementPermissions.Delete)]
        private void TsmiTemplates_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<Templates>();
        }

        [RequirePermission(UserManagementPermissions.Select | UserManagementPermissions.Create | UserManagementPermissions.Update | UserManagementPermissions.Delete)]
        [RequirePermission(GroupManagementPermissions.Select | GroupManagementPermissions.Create | GroupManagementPermissions.Update | GroupManagementPermissions.Delete)]
        private void TsmiUserAndGroupManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<UserAndGroupManagement>();
        }

        [RequirePermission(UserManagementPermissions.Select | UserManagementPermissions.Update)]
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

        [RequirePermission(DisplayManagementPermissions.Select | DisplayManagementPermissions.Update)]
        private void TsmiDisplaySettings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<DisplaySettings>();
        }

        [RequirePermission(LanguageManagementPermissions.Update)]
        private void TsmiLanguageEditor_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            AppStarter.Start(Path.Combine(Application.StartupPath, "Languages.ods"), String.Empty, presenter.Logger);
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

        [RequirePermission(SerialDeviceManagementPermissions.Select)]
        private void TsmiBarCodeReadings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<BarcodeReadings>();
        }

        [RequirePermission(CameraManagementPermissions.Pause | CameraManagementPermissions.Play | CameraManagementPermissions.Next | CameraManagementPermissions.Previous | CameraManagementPermissions.GoTo)]
        private void TsmiSyncronView_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<SyncronView>();
        }

        [RequirePermission(IODeviceManagementPermissions.Select | IODeviceManagementPermissions.Update)]
        private void TsmiIOPortsSettings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<IOPortSettings>();
        }

        [RequirePermission(CameraManagementPermissions.MotionPopupSettings)]
        private void TsmiMotionPopup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<CameraMotionSettings>();
        }

        [RequirePermission(MapManagementPermissions.Create | MapManagementPermissions.Update | MapManagementPermissions.Delete | MapManagementPermissions.Select)]
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
            if (Globals.ControlCenter != null)
            {
                Cursor.Position = Globals.ControlCenter.HomeLocation;
                WinAPI.SetCursorPos(Globals.ControlCenter.HomeLocation.X, Globals.ControlCenter.HomeLocation.Y);
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
            tsslOsUptime.Text = osUptime.Days < 2 ? $"{Globals.SystemUptime}: {osUptime.Days} {Globals.Day} {osUptime.Hours:D2}:{osUptime.Minutes:D2}:{osUptime.Seconds:D2}" : $"{Globals.SystemUptime}: {osUptime.Days} {Globals.Days} {osUptime.Hours:D2}:{appUptime.Minutes:D2}:{osUptime.Seconds:D2}";
            tsslUptime.Text = appUptime.Days < 2 ? $"{Globals.Uptime}: {appUptime.Days} {Globals.Day} {appUptime.Hours:D2}:{appUptime.Minutes:D2}:{appUptime.Seconds:D2}" : $"{Globals.Uptime}: {appUptime.Days} {Globals.Days} {appUptime.Hours:D2}:{appUptime.Minutes:D2}:{appUptime.Seconds:D2}";
        }

        [RequirePermission(EventManagementPermissions.Update)]
        private void LvUserEvents_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ChangeEvent(e.Item.Tag as UserEvent);
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
