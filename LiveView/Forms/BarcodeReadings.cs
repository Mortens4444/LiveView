using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class BarcodeReadings : Form, IBarcodeReadingsView
    {
        private readonly ILogger<BarcodeReadings> logger;

        public BarcodeReadings(ILogger<BarcodeReadings> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
