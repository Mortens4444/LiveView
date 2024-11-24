using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class LicenseFormPresenter
    {
        private readonly ILicenseFormView licenseFormView;

        public LicenseFormPresenter(ILicenseFormView licenseFormView)
        {
            this.licenseFormView = licenseFormView;
        }
    }
}
