using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ServerAndCameraManagement : Form, IServerAndCameraManagementView
    {
        private readonly FormFactory formFactory;
        private readonly ILogger<ServerAndCameraManagement> logger;

        public ServerAndCameraManagement(FormFactory formFactory, ILogger<ServerAndCameraManagement> logger)
        {
            InitializeComponent();
            this.formFactory = formFactory;
            this.logger = logger;
            btn_NewCamera.Tag = "Btn_NewCamera_Click";
            Translator.Translate(this);
        }

        [RequirePermission(PermissionType.CreateCamera)]
        private void Btn_NewCamera_Click(object sender, System.EventArgs e)
        {
            var form = formFactory.CreateForm<AddCameras>(1L, 2L);
            form.Show();
        }
    }
}
