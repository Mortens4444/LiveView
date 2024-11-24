using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class IOPortEditor : Form, IIOPortEditorView
    {
        private readonly ILogger<IOPortEditor> logger;

        public IOPortEditor(ILogger<IOPortEditor> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
