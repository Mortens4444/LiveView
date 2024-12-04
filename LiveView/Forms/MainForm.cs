using LanguageService;
using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.HardwareKey;
using Mtf.HardwareKey.Extensions;
using Mtf.HardwareKey.Interfaces;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Enums;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Models;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class MainForm : BaseView, IMainView
    {
        private readonly FormFactory formFactory;
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
            this.formFactory = formFactory;
            this.permissionManager = permissionManager;

            tsmiExit.Tag = nameof(Exit);
            //permissionManager.ApplyPermissionsOnControls(this);

            permissionManager.SetUser(this, new User
            {
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Exit())
            {
                e.Cancel = true;
            }
        }

        private void TsmiExit_Click(object sender, EventArgs e)
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
    }
}
