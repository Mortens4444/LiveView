using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class DisplayProperties : Form, IDisplayPropertiesView
    {
        private readonly ILogger<DisplayProperties> logger;

        public DisplayProperties(ILogger<DisplayProperties> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
