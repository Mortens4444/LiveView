using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AutoCreateWizard : Form, IAutoCreateWizardView
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
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            autoCreateWizardPresenter.CloseForm();
        }
    }
}
