using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class BarcodeReadings : BaseView, IBarcodeReadingsView
    {
        private BarcodeScanReadingsPresenter presenter;

        public ListView LvScans => lvScans;

        public BarcodeReadings(IServiceProvider serviceProvider) : base(serviceProvider, typeof(BarcodeScanReadingsPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

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
            presenter = Presenter as BarcodeScanReadingsPresenter;
            presenter.Load();
        }
    }
}
