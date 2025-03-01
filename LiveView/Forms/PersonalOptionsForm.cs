using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class PersonalOptionsForm : BaseView, IPersonalOptionsView
    {
        private PersonalOptionsPresenter presenter;
        private readonly Dictionary<object, string> originalTexts;

        public ComboBox CbLanguages => cbLanguages;

        public CheckBox ChkUseCustomColors => chkUseCustomColors;

        public RadioButton RbDisplayedName => rbDisplayedName;

        public RadioButton RbIpAddress => rbIpAddress;

        public RadioButton RbNone => rbNone;

        public NumericUpDown NudLargeFontSize => nudLargeFontSize;

        public NumericUpDown NudSmallFontSize => nudSmallFontSize;

        public MtfPictureBox PbFontColor => pbFontColor;

        public MtfPictureBox PbFontShadowColor => pbFontShadowColor;

        public Font CameraFont => lblTest.Font;

        public ColorDialog CdColorPicker => cdColorPicker;

        public FontDialog FdFontPicker => fdFontPicker;

        public Label LblTest => lblTest;

        public PersonalOptionsForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(PersonalOptionsPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            originalTexts = Translator.Translate(this);
        }

        private void PersonalOptionsForm_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as PersonalOptionsPresenter;
            presenter.Load();
        }

        public void SetOriginalTexts()
        {
            Translator.SetOriginalTexts(originalTexts);
        }

        private void CbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbLanguages.SelectedIndexChanged -= CbLanguages_SelectedIndexChanged;
            presenter.ChangeLanguage();
            CbLanguages.SelectedIndexChanged += CbLanguages_SelectedIndexChanged;
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

        private void BtnFontType_Click(object sender, EventArgs e)
        {
            presenter.ChangeCameraFont();
        }

        private void PbFontColor_Click(object sender, EventArgs e)
        {
            presenter.ChangeFontColor();
        }

        private void PbFontShadowColor_Click(object sender, EventArgs e)
        {
            presenter.ChangeFontShadowColor();
        }
    }
}
