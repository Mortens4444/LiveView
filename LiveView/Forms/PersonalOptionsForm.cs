using LiveView.Extensions;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService;
using Mtf.LanguageService.Enums;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using Language = Mtf.LanguageService.Enums.Language;

namespace LiveView.Forms
{
    public partial class PersonalOptionsForm : BaseView, IPersonalOptionsView
    {
        private PersonalOptionsPresenter presenter;

        public PersonalOptionsForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(PersonalOptionsPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

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
            presenter = Presenter as PersonalOptionsPresenter;
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
