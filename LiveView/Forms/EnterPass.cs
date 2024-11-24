using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class EnterPass : Form, IEnterPassView
    {
        private readonly ILogger<EnterPass> logger;

        public EnterPass(ILogger<EnterPass> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
