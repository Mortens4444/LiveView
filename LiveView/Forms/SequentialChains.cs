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

namespace LiveView.Forms
{
    public partial class SequentialChains : BaseView, ISequentialChainsView
    {
        private readonly SequentialChainsPresenter sequentialChainsPresenter;
        private readonly PermissionManager permissionManager;

        public SequentialChains(PermissionManager permissionManager, ILogger<SequentialChains> logger, ISequenceRepository<Sequence> sequenceRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            sequentialChainsPresenter = new SequentialChainsPresenter(this, sequenceRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(SequenceManagementPermissions.Delete)]
        private void BtnDeleteSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            sequentialChainsPresenter.DeleteSequence();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnAddGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            sequentialChainsPresenter.AddGrid();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            sequentialChainsPresenter.MoveGridUp();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            sequentialChainsPresenter.MoveGridDown();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnDeleteGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            sequentialChainsPresenter.DeleteGrid();
        }

        [RequirePermission(SequenceManagementPermissions.Create)]
        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnAddOrUpdateSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            sequentialChainsPresenter.AddOrMUpdateSequence();
        }

        private void SequentialChains_Shown(object sender, EventArgs e)
        {
            sequentialChainsPresenter.Load();
        }
    }
}
