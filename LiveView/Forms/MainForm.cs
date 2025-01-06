using LiveView.Core.Dto;
using LiveView.Core.Services;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.HardwareKey;
using Mtf.HardwareKey.Extensions;
using Mtf.HardwareKey.Interfaces;
using Mtf.LanguageService;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using User = Mtf.Permissions.Models.User;

namespace LiveView.Forms
{
    public partial class MainForm : BaseView, IMainView
    {
        private MainPresenter presenter;

        private static string Uptime;
        private static string SystemUptime;        
        private static string Day;
        private static string Days;

        public static readonly IHardwareKey HardwareKey;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ControlCenter ControlCenter { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static DisplayDto FullScreenDisplay { get; set; }

        public ToolStripStatusLabel TsslServerData => tsslServerData;

        static MainForm()
        {
            HardwareKey = new VirtualSziltechHardwareKey();
            //HardwareKey = new SziltechHardwareKey();
            HardwareKey.GetDescription();
        }

        public MainForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(MainPresenter))
        {
            InitializeComponent();

            //permissionManager.ApplyPermissionsOnControls(this);
            var user = new User
            {
                Id = 1,
                IndividualPermissions = new List<Permission>
                {
                    new Permission { PermissionGroup = typeof(GridManagementPermissions), PermissionValue = (long)GridManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(SequenceManagementPermissions), PermissionValue = (long)SequenceManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(LogManagementPermissions), PermissionValue = (long)LogManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(IODeviceManagementPermissions), PermissionValue = (long)IODeviceManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(MapManagementPermissions), PermissionValue = (long)MapManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(DatabaseServerManagementPermissions), PermissionValue = (long)DatabaseServerManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(GroupManagementPermissions), PermissionValue = (long)GroupManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(UserManagementPermissions), PermissionValue = (long)UserManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(PermissionManagementPermissions), PermissionValue = (long)PermissionManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(JoystickManagementPermissions), PermissionValue = (long)JoystickManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(NetworkManagementPermissions), PermissionValue = (long)NetworkManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(PasswordManagementPermissions), PermissionValue = (long)PasswordManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(SerialDeviceManagementPermissions), PermissionValue = (long)SerialDeviceManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(TemplateManagementPermissions), PermissionValue = (long)TemplateManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(LanguageManagementPermissions), PermissionValue = (long)LanguageManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(HardwareManagementPermissions), PermissionValue = (long)HardwareManagementPermissions.FullControl },

                    new Permission { PermissionGroup = typeof(CameraManagementPermissions), PermissionValue = (long)CameraManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(ServerManagementPermissions), PermissionValue = (long)ServerManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(SettingsManagementPermissions), PermissionValue = (long)SettingsManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(ApplicationManagementPermissions), PermissionValue = (long)ApplicationManagementPermissions.Exit },
                    new Permission { PermissionGroup = typeof(DisplayManagementPermissions), PermissionValue = (long)DisplayManagementPermissions.FullControl},
                    new Permission { PermissionGroup = typeof(WindowManagementPermissions), PermissionValue = (long)WindowManagementPermissions.FullControl},
                }
            };
            permissionManager.SetUser(this, user);

            Translator.Translate(this);

            Uptime = Lng.Elem("Uptime");
            SystemUptime = Lng.Elem("System uptime");
            Day = Lng.Elem("day");
            Days = Lng.Elem("days");
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
            Process.Start(Path.Combine(Application.StartupPath, "Languages.ods"));
        }

        [RequirePermission(LogManagementPermissions.Select)]
        private void TsmiLogViewer_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<LogViewer>();
        }

        private void TsmiPositioningMousePointer_Click(object sender, EventArgs e)
        {
            presenter.MoveMouseToHome();
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
            presenter.ShowForm<MapCreator>();
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            presenter.ShowForm<About>();
        }

        private void TsmiLicense_Click(object sender, EventArgs e)
        {
            presenter.ShowForm<LicenseForm>();
        }

        [RequirePermission(ApplicationManagementPermissions.Exit)]
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            permissionManager.EnsurePermissions();
            if (!presenter.Exit())
            {
                e.Cancel = true;
            }
        }

        [RequirePermission(ApplicationManagementPermissions.Exit)]
        private void TsmiExit_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Exit();
        }

        private void BtnLoginLogoutPrimary_Click(object sender, EventArgs e)
        {
            presenter.PrimaryLogon();
        }

        private void BtnLoginLogoutSecondary_Click(object sender, EventArgs e)
        {
            presenter.SecondaryLogon();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as MainPresenter;
            presenter.Load();
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
    }
}
