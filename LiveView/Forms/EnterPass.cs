using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class EnterPass : BaseView, IEnterPassView
    {
        private EnterPassPresenter presenter;

        public EnterPass(IServiceProvider serviceProvider) : base(serviceProvider, typeof(EnterPassPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(DatabaseServerManagementPermissions.FullControl)]
        private void BtnOK_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Login();
        }

        private void EnterPass_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as EnterPassPresenter;
        }
    }
}
