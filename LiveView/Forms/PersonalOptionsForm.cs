using Database.Interfaces;
using Database.Models;
using LanguageService;
using LanguageService.Windows.Forms;
using LiveView.Extensions;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Enums;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using Language = LanguageService.Language;

namespace LiveView.Forms
{
    public partial class PersonalOptionsForm : BaseView, IPersonalOptionsView
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            personalOptionsPresenter.SaveSettings();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            personalOptionsPresenter.CloseForm();
        }

        private void PersonalOptionsForm_Shown(object sender, EventArgs e)
        {
            personalOptionsPresenter.Load();
            foreach (ImplementedLanguage language in Enum.GetValues(typeof(ImplementedLanguage)))
            {
                var description = language.GetDescription();
                cbLanguages.Items.Add($"{language} ({description})");
            }
        }

        private void CbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cbLanguages.SelectedItem?.ToString();
            if (!String.IsNullOrEmpty(selectedItem))
            {
                var languageEnum = EnumExtensions.GetFromDescription<Language>(selectedItem);
                Lng.DefaultLanguage = languageEnum;
            }
        }
    }
}
