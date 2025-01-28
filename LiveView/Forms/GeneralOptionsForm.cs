using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class GeneralOptionsForm : BaseView, IGeneralOptionsView
    {
        private GeneralOptionsPresenter presenter;

        public NumericUpDown NudFPS => nudFPS;

        public NumericUpDown NudRestartTemplate => nudRestartTemplate;

        public NumericUpDown NudMaximumTimeToWaitForNewPicture => nudMaximumTimeToWaitForNewPicture;

        public NumericUpDown NudMaximumDeflectionBetweenLiveViewAndRecorder => nudMaximumDeflectionBetweenLiveViewAndRecorder;

        public NumericUpDown NudStatisticMessageAfterEveryMinutes => nudStatisticMessageAfterEveryMinutes;

        public NumericUpDown NudTimeBetweenCheckVideoServers => nudTimeBetweenCheckVideoServers;

        public NumericUpDown NudMaximumTimeToWaitForAVideoServerIs => nudMaximumTimeToWaitForAVideoServerIs;

        public CheckBox ChkReduceSequenceUsageOfNetworkAndCPU => chkReduceSequenceUsageOfNetworkAndCPU;

        public CheckBox ChkDeblock => chkDeblock;

        public CheckBox ChkCloseSequenceApplicationOnFullScreenDisplayDevice => chkCloseSequenceApplicationOnFullScreenDisplayDevice;

        public CheckBox ChkLiveView => chkLiveView;

        public CheckBox ChkThreading => chkThreading;

        public CheckBox ChkOpenMotionPopupWhenProgramStarts => chkOpenMotionPopupWhenProgramStarts;
        
        public CheckBox ChkOpenControlCenterWhenProgramStarts => chkOpenControlCenterWhenProgramStarts;
        
        public CheckBox ChkUseCustomNoSignalImage => chkUseCustomNoSignalImage;

        public CheckBox ChkVerboseDebugLogging => chkVerboseDebugLogging;

        public CheckBox ChkUseWatchDog => chkUseWatchDog;

        public ComboBox CbKBD300ACOMPort => cbKBD300ACOMPort;

        public ComboBox CbUsers => cbUsers;

        public ComboBox CbAutoLoadedTemplate => cbAutoLoadedTemplate;

        public TextBox TbDatabaseUsage => tbDatabaseUsage;

        public TextBox TbDatabaseFolder => tbDatabaseFolder;

        public TextBox TbDataSource => tbDataSource;

        public TextBox TbUsername => tbUsername;

        public TextBox TbDatabaseName => tbDatabaseName;

        public MtfPictureBox PbStatus => pbStatus;

        public MtfPictureBox PbNoSignalImage => pbNoSignalImage;

        public RadioButton RbVerboseLogEveryEvents => rbVerboseLogEveryEvents;

        public RadioButton RbVerboseLogOnlyErrors => rbVerboseLogOnlyErrors;

        public FolderBrowserDialog FolderBrowserDialog => folderBrowserDialog;

        public CheckBox ChkIntegratedSecurity => chkIntegratedSecurity;

        public CheckBox ChkEncrypt => chkEncrypt;

        public CheckBox ChkPooling => chkPooling;

        public Label LblPassword => lblPassword;

        public TextBox TbPassword => tbPassword;

        public NumericUpDown NudConnectionTimeout => nudConnectionTimeout;

        public SaveFileDialog SaveFileDialog => saveFileDialog;

        public GeneralOptionsForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(GeneralOptionsPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(DatabaseServerManagementPermissions.Update)]
        private void BtnChangeDatabaseDirectory_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.ChangeNosignalImage)]
        private void BtnNoSignalImageBrowse_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SelectNoSignalImage();
        }

        [RequirePermission(SettingsManagementPermissions.UpdateStatic)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveSettings();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(SettingsManagementPermissions.SelectStatic)]
        private void BtnDefault_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.LoadDefaultSettings();
        }

        [RequirePermission(SettingsManagementPermissions.SelectStatic)]
        private void BtnStandard_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.LoadStandardSettings();
        }

        [RequirePermission(SettingsManagementPermissions.SelectStatic)]
        private void GeneralOptionsForm_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as GeneralOptionsPresenter;
            permissionManager.EnsurePermissions();
            presenter.Load();
        }

        private void BtnGenerateConfigFile_Click(object sender, EventArgs e)
        {
            presenter.GenerateConfigFile();
        }

        private void ChkIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            presenter.ChangeIntegratedSecurity();
        }
    }
}
