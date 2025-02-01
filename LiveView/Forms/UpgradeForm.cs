using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class UpgradeForm : BaseView, IUpgradeFormView
    {
        private UpgradeFormPresenter presenter;

        public TextBox TbSecretCode => tbSecretCode;

        public RichTextBox RtbUpgradeCode => rtbUpgradeCode;

        public UpgradeForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(UpgradeFormPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(DatabaseServerManagementPermissions.FullControl)]
        private void BtnUpgrade_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Upgrade();
        }

        private void EnterPass_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as UpgradeFormPresenter;
        }
    }
}
