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
    public partial class IOPortEditor : Form, IIOPortEditorView
    {
        private readonly IOPortEditorPresenter ioPortEditorPresenter;
        private readonly PermissionManager permissionManager;

        public IOPortEditor(PermissionManager permissionManager, ILogger<IOPortEditor> logger, IIOPortRepository<IOPort> ioPortRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            ioPortEditorPresenter = new IOPortEditorPresenter(this, ioPortRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(IODeviceManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ioPortEditorPresenter.CloseForm();
        }
    }
}
