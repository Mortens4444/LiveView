using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class SystemOptions : Form, ISystemOptionsView
    {
        private readonly ILogger<SystemOptions> logger;

        public SystemOptions(ILogger<SystemOptions> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
