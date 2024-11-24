using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LoginForm : Form, ILoginFormView
    {
        private readonly ILogger<LoginForm> logger;

        public LoginForm(ILogger<LoginForm> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
