using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.LanguageService.Enums;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using Language = Mtf.LanguageService.Enums.Language;

namespace LiveView.Forms
{
    public partial class PersonalOptionsForm : BaseView, IPersonalOptionsView
    {
        private readonly PersonalOptionsPresenter presenter;

        public PersonalOptionsForm(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<PersonalOptionsForm> logger, IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository)
            : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new PersonalOptionsPresenter(this, generalOptionsRepository, personalOptionsRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(SettingsManagementPermissions.UpdatePersonal)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveSettings();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void PersonalOptionsForm_Shown(object sender, EventArgs e)
        {
            presenter.Load();
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
