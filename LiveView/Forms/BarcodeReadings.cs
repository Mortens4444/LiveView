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
        private readonly BarcodeReadingsPresenter barcodeReadingsPresenter;
        private readonly PermissionManager permissionManager;

        public BarcodeReadings(PermissionManager permissionManager, ILogger<BarcodeReadings> logger)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            barcodeReadingsPresenter = new BarcodeReadingsPresenter(this, logger);

            Translator.Translate(this);
        }

        [RequirePermission(SerialDeviceManagementPermissions.Select)]
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            barcodeReadingsPresenter.Query();
        }

        private void BarcodeReadings_Shown(object sender, EventArgs e)
        {
            barcodeReadingsPresenter.Load();
        }
    }
}
