using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AutoCreateWizard : Form, IAutoCreateWizardView
    {
        private readonly ILogger<AutoCreateWizard> logger;

        public AutoCreateWizard(ILogger<AutoCreateWizard> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
