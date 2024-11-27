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
    public partial class Templates : Form, ITemplatesView
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
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(TemplateManagementPermissions.Delete)]
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            templatesPresenter.CloseForm();
        }
    }
}
