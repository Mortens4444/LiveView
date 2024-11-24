using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddDatabaseServer : Form, IAddDatabaseServerView
    {
        private readonly ILogger<AddDatabaseServer> logger;

        public AddDatabaseServer(ILogger<AddDatabaseServer> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
