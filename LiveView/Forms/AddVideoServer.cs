using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddVideoServer : Form, IAddVideoServerView
    {
        private readonly ILogger<AddVideoServer> logger;

        public AddVideoServer(ILogger<AddVideoServer> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
