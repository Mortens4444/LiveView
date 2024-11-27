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

            tsmi_ServerAndCameraManagement.Tag = nameof(Tsmi_ServerAndCameraManagement_Click);
            tsmi_GridManagement.Tag = nameof(Tsmi_GridManagement_Click);
            tsmi_SequentialChains.Tag = nameof(Tsmi_SequentialChains_Click);
            tsmi_AutoCreateWizard.Tag = nameof(Tsmi_AutoCreateWizard_Click);
            tsmi_Templates.Tag = nameof(Tsmi_Templates_Click);

            permissionManager.SetUser(this, new User
            {
                IndividualPermissions = new List<Permission>
                {
                    new Permission { PermissionGroup = typeof(ApplicationManagementPermissions), PermissionValue = (long)ApplicationManagementPermissions.Exit }
                }
            });
            //permissionManager.ApplyPermissionsOnControls(this);

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
            mainPresenter.ShowForm<ServerAndCameraManagement>();
        }

        [RequirePermission(GridManagementPermissions.FullControl)]
        private void Tsmi_GridManagement_Click(object sender, EventArgs e)
        {
            mainPresenter.ShowForm<GridManager>();
        }

        [RequirePermission(SequenceManagementPermissions.FullControl)]
        private void Tsmi_SequentialChains_Click(object sender, EventArgs e)
        {
            mainPresenter.ShowForm<SequentialChains>();
        }

        [RequirePermission(GridManagementPermissions.FullControl)]
        [RequirePermission(SequenceManagementPermissions.FullControl)]
        [RequirePermission(TemplateManagementPermissions.FullControl)]
        private void Tsmi_AutoCreateWizard_Click(object sender, EventArgs e)
        {
            mainPresenter.ShowForm<AutoCreateWizard>();
        }

        [RequirePermission(TemplateManagementPermissions.FullControl)]
        private void Tsmi_Templates_Click(object sender, EventArgs e)
        {
            mainPresenter.ShowForm<Templates>();
        }

        [RequirePermission(UserManagementPermissions.FullControl)]
        [RequirePermission(GroupManagementPermissions.FullControl)]
        private void Tsmi_UserAndGroupManagement_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(UserManagementPermissions.FullControl)]
        private void Tsmi_Profile_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(SettingsManagementPermissions.PersonalSettingsManagement)]

        private void Tsmi_PersonalOptions_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(SettingsManagementPermissions.StaticSettingsManagement)]
        private void Tsmi_GeneralOptions_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(DisplayManagementPermissions.FullControl)]
        private void Tsmi_DisplaySettings_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(LanguageManagementPermissions.Update)]
        private void Tsmi_LanguageEditor_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(LogManagementPermissions.Select)]
        private void Tsmi_LogViewer_Click(object sender, EventArgs e)
        {

        }

        private void Tsmi_PositioningMousePointer_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(SerialDeviceManagementPermissions.FullControl)]
        private void Tsmi_BarCodeReadings_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(CameraManagementPermissions.FullControl)]
        private void Tsmi_SyncronView_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(IODeviceManagementPermissions.FullControl)]
        private void Tsmi_IOPortsSettings_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(CameraManagementPermissions.FullControl)]
        private void Tsmi_MotionPopup_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(MapManagementPermissions.FullControl)]
        private void Tsmi_MapCreator_Click(object sender, EventArgs e)
        {

        }

        private void Tsmi_About_Click(object sender, EventArgs e)
        {

        }

        private void Tsmi_License_Click(object sender, EventArgs e)
        {

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

                return true;
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
