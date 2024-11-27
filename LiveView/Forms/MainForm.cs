using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Models;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using Mtf.MessageBoxes;
using LanguageService;
using Mtf.MessageBoxes.Enums;
using System.Diagnostics;
using System.IO;

namespace LiveView.Forms
{
    public partial class MainForm : Form, IMainView
    {
        private readonly FormFactory formFactory;
        private readonly MainPresenter mainPresenter;
        private readonly PermissionManager permissionManager;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ControlCenter ControlCenter { get; private set; }

        public MainForm(PermissionManager permissionManager, ILogger<MainForm> logger, FormFactory formFactory)
        {
            InitializeComponent();
            this.formFactory = formFactory;
            this.permissionManager = permissionManager;

            tsmi_Exit.Tag = nameof(Exit);
            //permissionManager.ApplyPermissionsOnControls(this);

            permissionManager.SetUser(this, new User
            {
                IndividualPermissions = new List<Permission>
                {
                    new Permission { PermissionGroup = typeof(ApplicationManagementPermissions), PermissionValue = (long)ApplicationManagementPermissions.Exit }
                }
            });

            mainPresenter = new MainPresenter(formFactory, this, logger);

            Translator.Translate(this);
        }

        private void Tsmi_ControlCenter_Click(object sender, EventArgs e)
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
        private void Tsmi_ServerAndCameraManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<ServerAndCameraManagement>();
        }

        [RequirePermission(GridManagementPermissions.FullControl)]
        private void Tsmi_GridManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<GridManager>();
        }

        [RequirePermission(SequenceManagementPermissions.FullControl)]
        private void Tsmi_SequentialChains_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<SequentialChains>();
        }

        [RequirePermission(GridManagementPermissions.FullControl)]
        [RequirePermission(SequenceManagementPermissions.FullControl)]
        [RequirePermission(TemplateManagementPermissions.FullControl)]
        private void Tsmi_AutoCreateWizard_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<AutoCreateWizard>();
        }

        [RequirePermission(TemplateManagementPermissions.FullControl)]
        private void Tsmi_Templates_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<Templates>();
        }

        [RequirePermission(UserManagementPermissions.FullControl)]
        [RequirePermission(GroupManagementPermissions.FullControl)]
        private void Tsmi_UserAndGroupManagement_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<UserAndGroupManagement>();
        }

        [RequirePermission(UserManagementPermissions.FullControl)]
        private void Tsmi_Profile_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<Profile>();
        }

        [RequirePermission(SettingsManagementPermissions.PersonalSettingsManagement)]

        private void Tsmi_PersonalOptions_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<PersonalOptionsForm>();
        }

        [RequirePermission(SettingsManagementPermissions.StaticSettingsManagement)]
        private void Tsmi_GeneralOptions_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<GeneralOptionsForm>();
        }

        [RequirePermission(DisplayManagementPermissions.FullControl)]
        private void Tsmi_DisplaySettings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<DisplayOptions>();
        }

        [RequirePermission(LanguageManagementPermissions.Update)]
        private void Tsmi_LanguageEditor_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            Process.Start(Path.Combine(Application.StartupPath, "Languages.ods"));
        }

        [RequirePermission(LogManagementPermissions.Select)]
        private void Tsmi_LogViewer_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<LogViewer>();
        }

        private void Tsmi_PositioningMousePointer_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(SerialDeviceManagementPermissions.FullControl)]
        private void Tsmi_BarCodeReadings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<BarcodeReadings>();
        }

        [RequirePermission(CameraManagementPermissions.FullControl)]
        private void Tsmi_SyncronView_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<SyncronView>();
        }

        [RequirePermission(IODeviceManagementPermissions.FullControl)]
        private void Tsmi_IOPortsSettings_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<IOPortSettings>();
        }

        [RequirePermission(CameraManagementPermissions.FullControl)]
        private void Tsmi_MotionPopup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<CameraMotionOptions>();
        }

        [RequirePermission(MapManagementPermissions.FullControl)]
        private void Tsmi_MapCreator_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mainPresenter.ShowForm<MapCreator>();
        }

        private void Tsmi_About_Click(object sender, EventArgs e)
        {
            mainPresenter.ShowForm<About>();
        }

        private void Tsmi_License_Click(object sender, EventArgs e)
        {
            mainPresenter.ShowForm<LicenseForm>();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Exit())
            {
                e.Cancel = true;
            }
        }

        private void Tsmi_Exit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        [RequirePermission(ApplicationManagementPermissions.Exit)]
        private bool Exit()
        {
            try
            {
                permissionManager.EnsurePermissions();
                if (ConfirmBox.Show(Lng.Elem("Confirmation"), Lng.Elem("Are you sure you want to exit?"), Decide.No) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ErrorBox.Show(ex);
                return false;
            }
        }

        private void Btn_LoginLogoutPrimary_Click(object sender, EventArgs e)
        {

        }

        private void Btn_LoginLogoutSecondary_Click(object sender, EventArgs e)
        {

        }
    }
}
