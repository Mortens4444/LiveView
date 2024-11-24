using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class IOPortSettings : Form, IIOPortSettingsView
    {
        private readonly ILogger<IOPortSettings> logger;

        public IOPortSettings(ILogger<IOPortSettings> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
