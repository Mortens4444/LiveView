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
    public partial class PersonalOptionsForm : Form, IPersonalOptionsView
    {
        private readonly PersonalOptionsPresenter personalOptionsPresenter;
        private readonly PermissionManager permissionManager;

        public PersonalOptionsForm(PermissionManager permissionManager, ILogger<PersonalOptionsForm> logger, IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            personalOptionsPresenter = new PersonalOptionsPresenter(this, personalOptionsRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(SettingsManagementPermissions.UpdatePersonal)]
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            personalOptionsPresenter.CloseForm();
        }
    }
}
