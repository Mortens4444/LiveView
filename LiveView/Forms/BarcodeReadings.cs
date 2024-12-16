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
    public partial class BarcodeReadings : BaseView, IBarcodeReadingsView
    {
        private readonly BarcodeReadingsPresenter presenter;

        public BarcodeReadings(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<BarcodeReadings> logger) : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new BarcodeReadingsPresenter(this, generalOptionsRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(SerialDeviceManagementPermissions.Select)]
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Query();
        }

        private void BarcodeReadings_Shown(object sender, EventArgs e)
        {
            presenter.Load();
        }
    }
}
