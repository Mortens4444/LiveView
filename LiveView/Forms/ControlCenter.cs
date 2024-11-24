using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ControlCenter : Form, IControlCenterView
    {
        private readonly ILogger<ControlCenter> logger;

        public ControlCenter(ILogger<ControlCenter> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
