using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class PersonalOptionsForm : BaseView, IPersonalOptionsView
    {
        private PersonalOptionsPresenter presenter;
        private readonly Dictionary<object, string> originalTexts;

        public ComboBox CbLanguages => cbLanguages;


        public PersonalOptionsForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(PersonalOptionsPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            originalTexts = Translator.Translate(this);
        }

        public void SetOriginalTexts()
        {
            Translator.SetOriginalTexts(originalTexts);
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
        }

        private void CbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbLanguages.SelectedIndexChanged -= CbLanguages_SelectedIndexChanged;
            presenter.ChangeLanguage();
            CbLanguages.SelectedIndexChanged += CbLanguages_SelectedIndexChanged;
        }
    }
}
