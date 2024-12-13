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
    public partial class Templates : BaseView, ITemplatesView
    {
        private readonly TemplatesPresenter templatesPresenter;
        private readonly PermissionManager permissionManager;

        public Templates(PermissionManager permissionManager, ILogger<Templates> logger, ITemplateRepository<Template> templateRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            templatesPresenter = new TemplatesPresenter(this, templateRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(TemplateManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            templatesPresenter.Save();
        }

        [RequirePermission(TemplateManagementPermissions.Delete)]
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            templatesPresenter.Delete();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            templatesPresenter.CloseForm();
        }

        private void Templates_Shown(object sender, EventArgs e)
        {
            templatesPresenter.Load();
        }
    }
}
