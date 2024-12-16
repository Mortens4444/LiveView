using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class LicenseForm : BaseView, ILicenseFormView
    {
        private readonly LicenseFormPresenter presenter;

        public LicenseForm(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<LicenseForm> logger)
            : base(permissionManager)
        {
            InitializeComponent();

            presenter = new LicenseFormPresenter(this, generalOptionsRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        private void BtnUpgrade_Click(object sender, EventArgs e)
        {
            presenter.Upgrade();
        }

        private void LicenseForm_Shown(object sender, EventArgs e)
        {
            presenter.Load();
        }
    }
}
