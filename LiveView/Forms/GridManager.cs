using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class GridManager : Form, IGridManagerView
    {
        private readonly ILogger<GridManager> logger;

        public GridManager(ILogger<GridManager> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
