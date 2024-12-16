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
    public partial class SequentialChains : BaseView, ISequentialChainsView
    {
        private readonly SequentialChainsPresenter presenter;

        public SequentialChains(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<SequentialChains> logger, ISequenceRepository<Sequence> sequenceRepository)
            : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new SequentialChainsPresenter(this, generalOptionsRepository, sequenceRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(SequenceManagementPermissions.Delete)]
        private void BtnDeleteSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.DeleteSequence();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnAddGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddGrid();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveGridUp();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveGridDown();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnDeleteGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.DeleteGrid();
        }

        [RequirePermission(SequenceManagementPermissions.Create)]
        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnAddOrUpdateSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddOrMUpdateSequence();
        }

        private void SequentialChains_Shown(object sender, EventArgs e)
        {
            presenter.Load();
        }
    }
}
