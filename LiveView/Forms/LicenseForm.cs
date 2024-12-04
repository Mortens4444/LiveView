using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Forms
{
    public partial class LicenseForm : BaseView, ILicenseFormView
    {
        private readonly LicenseFormPresenter licenseFormPresenter;

        public LicenseForm(ILogger<LicenseForm> logger)
        {
            InitializeComponent();

            licenseFormPresenter = new LicenseFormPresenter(this, logger);

            Translator.Translate(this);
        }

        private void BtnUpgrade_Click(object sender, EventArgs e)
        {
            licenseFormPresenter.Upgrade();
        }

        private void LicenseForm_Shown(object sender, EventArgs e)
        {
            licenseFormPresenter.Load();
        }
    }
}
