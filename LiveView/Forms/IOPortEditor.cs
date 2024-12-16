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
        private readonly IOPortEditorPresenter presenter;

        public IOPortEditor(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<IOPortEditor> logger, IIOPortRepository<IOPort> ioPortRepository)
            : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new IOPortEditorPresenter(this, generalOptionsRepository, ioPortRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(IODeviceManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Save();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }
    }
}
