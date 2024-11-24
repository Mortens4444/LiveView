using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LogViewer : Form, ILogViewerView
    {
        private readonly ILogger<LogViewer> logger;

        public LogViewer(ILogger<LogViewer> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
