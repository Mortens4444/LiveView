using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LicenseForm : Form, ILicenseFormView
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
