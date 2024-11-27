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
    public partial class SequentialChains : Form, ISequentialChainsView
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
        private void Btn_DeleteSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void Btn_AddGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void Btn_MoveUp_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void Btn_MoveDown_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void Btn_DeleteGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void Btn_AddOrUpdateSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }
    }
}
