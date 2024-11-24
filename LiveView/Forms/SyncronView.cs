using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class SyncronView : Form, ISyncronViewView
    {
        private readonly ILogger<SyncronView> logger;

        public SyncronView(ILogger<SyncronView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
