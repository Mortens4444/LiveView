using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class MainForm : Form, IMainView
    {
        private readonly ILogger<MainForm> logger;
        private readonly FormFactory formFactory;

        public MainForm(PermissionManager permissionManager, ILogger<MainForm> logger, FormFactory formFactory)
        {
            InitializeComponent();
            this.logger = logger;
            this.formFactory = formFactory;

            tsmi_ServerAndCameraManagement.Tag = "Tsmi_ServerAndCameraManagement_Click";
            //permissionManager.SetUser(this, new Mtf.Permissions.Models.User { IndividualPermissions = new System.Collections.Generic.List<Mtf.Permissions.Models.Permission>{ new Mtf.Permissions.Models.Permission { PermissionType = Mtf.Permissions.Enums.PermissionType.Admin }} });
            permissionManager.ApplyPermissionsOnControls(this);
            Translator.Translate(this);
        }

        private void Tsmi_ControlCenter_Click(object sender, System.EventArgs e)
        {
        }

        private void Tsmi_ServerAndCameraManagement_Click(object sender, System.EventArgs e)
        {
            var form = formFactory.CreateForm<ServerAndCameraManagement>();
            form.Show();
        }
    }
}
