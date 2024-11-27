using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class BarcodeReadings : Form, IBarcodeReadingsView
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
        private void BtnQuery_Click(object sender, System.EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }
    }
}
