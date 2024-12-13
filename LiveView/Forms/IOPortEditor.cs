using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class IOPortEditor : BaseView, IIOPortEditorView
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
            ioPortEditorPresenter.Save();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ioPortEditorPresenter.CloseForm();
        }
    }
}
