using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.HardwareKey;
using Mtf.HardwareKey.Extensions;
using Mtf.HardwareKey.Interfaces;
using Mtf.LanguageService;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Models;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LiveView.Forms
{
    public partial class MainForm : BaseView, IMainView
    {
        private readonly MainPresenter mainPresenter;
        private readonly PermissionManager permissionManager;
        public static readonly IHardwareKey HardwareKey;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ControlCenter ControlCenter { get; private set; }

        static MainForm()
        {
            HardwareKey = new VirtualSziltechHardwareKey();
            //HardwareKey = new SziltechHardwareKey();
            HardwareKey.GetDescription();
        }

        public MainForm(PermissionManager permissionManager, ILogger<MainForm> logger, FormFactory formFactory)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            //permissionManager.ApplyPermissionsOnControls(this);
            permissionManager.SetUser(this, new User
            {
                Id = 1,
                IndividualPermissions = new List<Permission>
                {
                    new Permission { PermissionGroup = typeof(CameraManagementPermissions), PermissionValue = (long)CameraManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(ServerManagementPermissions), PermissionValue = (long)ServerManagementPermissions.FullControl },
                    new Permission { PermissionGroup = typeof(SettingsManagementPermissions), PermissionValue = (long)SettingsManagementPermissions.PersonalSettingsManagement },
                    new Permission { PermissionGroup = typeof(ApplicationManagementPermissions), PermissionValue = (long)ApplicationManagementPermissions.Exit }
                }
            });

            mainPresenter = new MainPresenter(formFactory, this, logger);

            Translator.Translate(this);
        }

        private void TsmiControlCenter_Click(object sender, EventArgs e)
        {
            if (ControlCenter == null)
            {
                ControlCenter = mainPresenter.ShowForm<ControlCenter>();
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
            mainPresenter.ShowForm<ServerAndCameraManagement>();
        }

        [RequirePermission(GridManagementPermissions.FullControl)]
        private void TsmiGridManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<GridManager>();
        }

        [RequirePermission(SequenceManagementPermissions.FullControl)]
        private void TsmiSequentialChains_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<SequentialChains>();
        }

        [RequirePermission(GridManagementPermissions.FullControl)]
        [RequirePermission(SequenceManagementPermissions.FullControl)]
        [RequirePermission(TemplateManagementPermissions.FullControl)]
        private void TsmiAutoCreateWizard_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<AutoCreateWizard>();
        }

        [RequirePermission(TemplateManagementPermissions.FullControl)]
        private void TsmiTemplates_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<Templates>();
        }

        [RequirePermission(UserManagementPermissions.FullControl)]
        [RequirePermission(GroupManagementPermissions.FullControl)]
        private void TsmiUserAndGroupManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<UserAndGroupManagement>();
        }

        [RequirePermission(UserManagementPermissions.FullControl)]
        private void TsmiProfile_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<Profile>();
        }

        [RequirePermission(SettingsManagementPermissions.PersonalSettingsManagement)]

        private void TsmiPersonalOptions_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<PersonalOptionsForm>();
        }

        [RequirePermission(SettingsManagementPermissions.StaticSettingsManagement)]
        private void TsmiGeneralOptions_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<GeneralOptionsForm>();
        }

        [RequirePermission(DisplayManagementPermissions.FullControl)]
        private void TsmiDisplaySettings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<DisplayOptions>();
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
            mainPresenter.ShowForm<LogViewer>();
        }

        private void TsmiPositioningMousePointer_Click(object sender, EventArgs e)
        {
            mainPresenter.MoveMouseToHome();
        }

        [RequirePermission(SerialDeviceManagementPermissions.FullControl)]
        private void TsmiBarCodeReadings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<BarcodeReadings>();
        }

        [RequirePermission(CameraManagementPermissions.FullControl)]
        private void TsmiSyncronView_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<SyncronView>();
        }

        [RequirePermission(IODeviceManagementPermissions.FullControl)]
        private void TsmiIOPortsSettings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<IOPortSettings>();
        }

        [RequirePermission(CameraManagementPermissions.FullControl)]
        private void TsmiMotionPopup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<CameraMotionOptions>();
        }

        [RequirePermission(MapManagementPermissions.FullControl)]
        private void TsmiMapCreator_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<MapCreator>();
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            mainPresenter.ShowForm<About>();
        }

        private void TsmiLicense_Click(object sender, EventArgs e)
        {
            mainPresenter.ShowForm<LicenseForm>();
        }

        [RequirePermission(ApplicationManagementPermissions.Exit)]
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            permissionManager.EnsurePermissions();
            if (!mainPresenter.Exit())
            {
                e.Cancel = true;
            }
        }

        [RequirePermission(ApplicationManagementPermissions.Exit)]
        private void TsmiExit_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.Exit();
        }

        private void BtnLoginLogoutPrimary_Click(object sender, EventArgs e)
        {
            mainPresenter.PrimaryLogon();
        }

        private void BtnLoginLogoutSecondary_Click(object sender, EventArgs e)
        {
            mainPresenter.SecondaryLogon();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            mainPresenter.Load();
        }

        public IntPtr GetHandle()
        {
            return Handle;
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;
            const int SC_SIZE = 0xF000;

            switch (m.Msg)
            {
                case WM_HOTKEY:
                    HandleHotkey(m);
                    break;

                case WM_SYSCOMMAND:
                    //if (permissionManager.User.Id != 1 && permissionManager.User.Id != 2)
                    //{
                    //    int command = m.WParam.ToInt32() & 0xFFF0;
                    //    if (command == SC_MOVE || command == SC_SIZE)
                    //    {
                    //        // Prevent the move/resize action
                    //        return;
                    //    }
                    //}
                    base.WndProc(ref m);
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
                    mainPresenter.SetCursorPosition();
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
            mainPresenter.SetUptime();
        }

        public void SetUptime(TimeSpan osUptime, TimeSpan appUptime)
        {
            tsslOsUptime.Text = osUptime.Days < 2 ? $"{Lng.Elem("Uptime")}: {osUptime.Days} {Lng.Elem("day")} {osUptime.Hours:D2}:{osUptime.Minutes:D2}:{osUptime.Seconds:D2}" : $"{Lng.Elem("Uptime")}: {osUptime.Days} {Lng.Elem("days")} {osUptime.Hours:D2}:{appUptime.Minutes:D2}:{osUptime.Seconds:D2}";
            tsslUptime.Text = appUptime.Days < 2 ? $"{Lng.Elem("Uptime")}: {appUptime.Days} {Lng.Elem("day")} {appUptime.Hours:D2}:{appUptime.Minutes:D2}:{appUptime.Seconds:D2}" : $"{Lng.Elem("Uptime")}: {appUptime.Days} {Lng.Elem("days")} {appUptime.Hours:D2}:{appUptime.Minutes:D2}:{appUptime.Seconds:D2}";
        }
    }
}
