using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class DisplayOptions : Form, IDisplayOptionsView
    {
        private readonly ILogger<DisplayOptions> logger;

        public DisplayOptions(ILogger<DisplayOptions> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
