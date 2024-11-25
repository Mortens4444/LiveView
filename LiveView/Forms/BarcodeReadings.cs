using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class BarcodeReadings : Form, IBarcodeReadingsView
    {
        private readonly BarcodeReadingsPresenter barcodeReadingsPresenter;

        public BarcodeReadings(PermissionManager permissionManager, ILogger<BarcodeReadings> logger)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            barcodeReadingsPresenter = new BarcodeReadingsPresenter(this, logger);

            Translator.Translate(this);
        }
    }
}
