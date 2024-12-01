using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;

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
    }
}
