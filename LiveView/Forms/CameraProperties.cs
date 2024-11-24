using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class CameraProperties : Form, ICameraPropertiesView
    {
        private readonly ILogger<CameraProperties> logger;

        public CameraProperties(ILogger<CameraProperties> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
