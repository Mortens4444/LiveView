using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class AutoCreateWizard : BaseView, IAutoCreateWizardView
    {
        private readonly AutoCreateWizardPresenter autoCreateWizardPresenter;
        private readonly PermissionManager permissionManager;

        public AutoCreateWizard(PermissionManager permissionManager, ILogger<AutoCreateWizard> logger, ITemplateRepository<Template> templateRepository, ISequenceRepository<Sequence> sequenceRepository, IGridRepository<Grid> gridRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            autoCreateWizardPresenter = new AutoCreateWizardPresenter(this, templateRepository, sequenceRepository, gridRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(GridManagementPermissions.FullControl)]
        [RequirePermission(SequenceManagementPermissions.FullControl)]
        [RequirePermission(TemplateManagementPermissions.FullControl)]
        private void BtnAutoCreate_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            autoCreateWizardPresenter.AutoCreate();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            autoCreateWizardPresenter.CloseForm();
        }

        [RequirePermission(GridManagementPermissions.Create)]
        [RequirePermission(SequenceManagementPermissions.Create)]
        [RequirePermission(TemplateManagementPermissions.Create)]
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            autoCreateWizardPresenter.AddSelected();
        }

        [RequirePermission(GridManagementPermissions.Create)]
        [RequirePermission(SequenceManagementPermissions.Create)]
        [RequirePermission(TemplateManagementPermissions.Create)]
        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            autoCreateWizardPresenter.AddAll();
        }

        [RequirePermission(GridManagementPermissions.Delete)]
        [RequirePermission(SequenceManagementPermissions.Delete)]
        [RequirePermission(TemplateManagementPermissions.Delete)]
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            autoCreateWizardPresenter.RemoveSelected();
        }

        [RequirePermission(GridManagementPermissions.Delete)]
        [RequirePermission(SequenceManagementPermissions.Delete)]
        [RequirePermission(TemplateManagementPermissions.Delete)]
        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            autoCreateWizardPresenter.RemoveAll();
        }

        private void AutoCreateWizard_Shown(object sender, EventArgs e)
        {
            autoCreateWizardPresenter.Load();
        }
    }
}
