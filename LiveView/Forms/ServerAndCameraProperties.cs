using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ServerAndCameraProperties : Form, IServerAndCameraPropertiesView
    {
        private readonly ILogger<ServerAndCameraProperties> logger;

        public ServerAndCameraProperties(ILogger<ServerAndCameraProperties> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
