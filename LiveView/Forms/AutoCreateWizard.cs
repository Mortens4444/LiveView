using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class AutoCreateWizard : BaseView, IAutoCreateWizardView
    {
        private AutoCreateWizardPresenter presenter;

        public AutoCreateWizard(IServiceProvider serviceProvider) : base(serviceProvider, typeof(AutoCreateWizardPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(GridManagementPermissions.FullControl)]
        [RequirePermission(SequenceManagementPermissions.FullControl)]
        [RequirePermission(TemplateManagementPermissions.FullControl)]
        private void BtnAutoCreate_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AutoCreate();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(GridManagementPermissions.Create)]
        [RequirePermission(SequenceManagementPermissions.Create)]
        [RequirePermission(TemplateManagementPermissions.Create)]
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            presenter.AddSelected();
        }

        [RequirePermission(GridManagementPermissions.Create)]
        [RequirePermission(SequenceManagementPermissions.Create)]
        [RequirePermission(TemplateManagementPermissions.Create)]
        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            presenter.AddAll();
        }

        [RequirePermission(GridManagementPermissions.Delete)]
        [RequirePermission(SequenceManagementPermissions.Delete)]
        [RequirePermission(TemplateManagementPermissions.Delete)]
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            presenter.RemoveSelected();
        }

        [RequirePermission(GridManagementPermissions.Delete)]
        [RequirePermission(SequenceManagementPermissions.Delete)]
        [RequirePermission(TemplateManagementPermissions.Delete)]
        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            presenter.RemoveAll();
        }

        private void AutoCreateWizard_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AutoCreateWizardPresenter;
            presenter.Load();
        }
    }
}
