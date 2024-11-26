using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class MainForm : Form, IMainView
    {
        private readonly FormFactory formFactory;
        private readonly MainPresenter mainPresenter;

        public MainForm(PermissionManager permissionManager, ILogger<MainForm> logger, FormFactory formFactory)
        {
            InitializeComponent();
            this.formFactory = formFactory;

            tsmi_ServerAndCameraManagement.Tag = "Tsmi_ServerAndCameraManagement_Click";
            //permissionManager.SetUser(this, new Mtf.Permissions.Models.User { IndividualPermissions = new System.Collections.Generic.List<Mtf.Permissions.Models.Permission>{ new Mtf.Permissions.Models.Permission { PermissionType = Mtf.Permissions.Enums.PermissionType.Admin }} });
            permissionManager.ApplyPermissionsOnControls(this);

            mainPresenter = new MainPresenter(formFactory, this, logger);

            Translator.Translate(this);
        }

        private void Tsmi_ControlCenter_Click(object sender, EventArgs e)
        {
        }

        private void Tsmi_ServerAndCameraManagement_Click(object sender, EventArgs e)
        {
            var form = formFactory.CreateForm<ServerAndCameraManagement>();
            form.Show();
        }
    }
}
