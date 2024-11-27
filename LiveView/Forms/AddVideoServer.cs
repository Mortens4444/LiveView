using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddVideoServer : Form, IAddVideoServerView
    {
        private readonly AddVideoServerPresenter addVideoServerPresenter;
        private readonly PermissionManager permissionManager;

        public AddVideoServer(PermissionManager permissionManager, ILogger<AddVideoServer> logger, IServerRepository<Sequence> serverRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            addVideoServerPresenter = new AddVideoServerPresenter(this, serverRepository, logger);

            Translator.Translate(this);
        }

        private void Btn_Validate_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(ServerManagementPermissions.Create)]
        private void Btn_AddOrModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            addVideoServerPresenter.CloseForm();
        }
    }
}
