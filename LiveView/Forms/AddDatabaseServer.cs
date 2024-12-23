using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class AddDatabaseServer : BaseView, IAddDatabaseServerView
    {
        private AddDatabaseServerPresenter presenter;

        public AddDatabaseServer(IServiceProvider serviceProvider) : base(serviceProvider, typeof(AddDatabaseServerPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(ServerManagementPermissions.Create)]
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddDatabaseServer();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void AddDatabaseServer_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddDatabaseServerPresenter;
        }
    }
}
