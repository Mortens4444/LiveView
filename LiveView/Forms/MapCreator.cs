using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class MapCreator : Form, IMapCreatorView
    {
        private readonly ILogger<MapCreator> logger;

        public MapCreator(ILogger<MapCreator> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
