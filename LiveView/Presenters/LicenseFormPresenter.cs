using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class LicenseFormPresenter : BasePresenter
    {
        private readonly ILicenseFormView licenseFormView;
        private readonly ILogger<LicenseForm> logger;

        public LicenseFormPresenter(ILicenseFormView licenseFormView, ILogger<LicenseForm> logger)
            : base(licenseFormView)
        {
            this.licenseFormView = licenseFormView;
            this.logger = logger;
        }

        public void Upgrade()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
