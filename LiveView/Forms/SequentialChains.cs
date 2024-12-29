using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class SequentialChains : BaseView, ISequentialChainsView
    {
        private SequentialChainsPresenter presenter;

        public ComboBox CbGrids => cbGrids;

        public ComboBox CbSequences => cbSequences;

        public ListView LvGrids => lvGrids;

        public TextBox TbSequenceName => tbSequenceName;

        public SequentialChains(IServiceProvider serviceProvider) : base(serviceProvider, typeof(SequentialChainsPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(SequenceManagementPermissions.Delete)]
        private void BtnDeleteSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.DeleteSequence();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnAddGridToSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddGridToSequence();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveGridsUp();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveGridsDown();
        }

        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnRemoveGridFromSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.RemoveGridFromSequence();
        }

        [RequirePermission(SequenceManagementPermissions.Create)]
        [RequirePermission(SequenceManagementPermissions.Update)]
        private void BtnSaveSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveSequence();
        }

        private void SequentialChains_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as SequentialChainsPresenter;
            presenter.Load();
        }

        public GridInSequence GetGridInSequence()
        {
            return new GridInSequence
            {
                SequenceId = ((Sequence)CbSequences.SelectedItem).Id,
                TimeToShow = (int)nudSecondsToShow.Value,
                GridId = ((Grid)CbGrids.SelectedItem).Id,
                Number = lvGrids.Items.Count,
            };
        }

        [RequirePermission(SequenceManagementPermissions.Select)]
        private void CbSequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.GetSequenceGrids();
        }
    }
}
