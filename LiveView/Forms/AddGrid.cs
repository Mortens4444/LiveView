using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddGrid : Form, IAddGridView
    {
        private readonly ILogger<AddGrid> logger;

        public AddGrid(ILogger<AddGrid> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
