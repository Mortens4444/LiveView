using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class CameraMotionOptions : Form, ICameraMotionOptionsView
    {
        private readonly ILogger<CameraMotionOptions> logger;

        public CameraMotionOptions(ILogger<CameraMotionOptions> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
