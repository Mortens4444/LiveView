using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LicenseForm : Form, ILicenseFormView
    {
        private readonly ILogger<LicenseForm> logger;

        public LicenseForm(ILogger<LicenseForm> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
