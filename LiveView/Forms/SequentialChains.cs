using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class SequentialChains : Form, ISequentialChainsView
    {
        private readonly ILogger<SequentialChains> logger;

        public SequentialChains(ILogger<SequentialChains> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
