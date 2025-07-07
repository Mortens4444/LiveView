using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Extensions;
using Mtf.HardwareKey.Enums;
using Mtf.MessageBoxes.Enums;
using Mtf.Permissions.Enums;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class SequentialChainsPresenter : BasePresenter
    {
        private ISequentialChainsView view;
        private readonly IGridRepository gridRepository;
        private readonly ISequenceRepository sequenceRepository;
        private readonly ISequenceGridsRepository sequenceGridsRepository;
        private readonly ILogger<SequentialChains> logger;

        public SequentialChainsPresenter(SequentialChainsPresenterDependencies dependencies)
            : base(dependencies)
        {
            gridRepository = dependencies.GridRepository;
            sequenceRepository = dependencies.SequenceRepository;
            sequenceGridsRepository = dependencies.SequenceGridsRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ISequentialChainsView;
        }

        public void AddGridToSequence()
        {
            var gridInSequence = view.GetGridInSequence();
            AddGridToListView(gridInSequence);
        }

        private void AddGridToListView(SequenceGrid gridInSequence)
        {
            var item = new ListViewItem(gridInSequence.Number.ToString())
            {
                Tag = gridInSequence
            };
            item.SubItems.Add(gridInSequence.TimeToShow.ToString());
            var grid = gridRepository.Select(gridInSequence.GridId);
            item.SubItems.Add(grid.Name);
            view.LvGrids.Items.Add(item);
        }

        public void SaveSequence()
        {
            if (Globals.HardwareKey.LiveViewEdition == LiveViewEdition.Basic && view.LvGrids.Items.Count > 1)
            {
                ShowError("Live View Basic Edition can only have 1 grid in a sequence.");
                return;
            }
            if (Globals.HardwareKey.LiveViewEdition == LiveViewEdition.Standard && view.LvGrids.Items.Count > 10)
            {
                ShowError("Live View Standard Edition can only have 10 grids in a sequence.");
                return;
            }

            int sequenceId;
            var sequence = view.GetSequence();
            if (sequence.Id == 0)
            {
                sequenceId = sequenceRepository.InsertAndReturnId<int>(sequence);
                logger.LogInfo(SequenceManagementPermissions.Create, "Sequence '{0}' has been created.", sequence.Name);
            }
            else
            {
                sequenceId = sequence.Id;
                sequenceRepository.Update(sequence);
                logger.LogInfo(SequenceManagementPermissions.Update, "Sequence '{0}' has been changed.", sequence.Name);
                sequenceGridsRepository.DeleteWhere(new { SequenceId = sequence.Id });
                logger.LogInfo(SequenceManagementPermissions.Update, "Grids have been deleted for sequence '{0}'.", sequence.Name);
            }

            var gridS = gridRepository.SelectAll();
            foreach (ListViewItem item in view.LvGrids.Items)
            {
                if (item.Tag is SequenceGrid gridInSequence)
                {
                    gridInSequence.SequenceId = sequenceId;
                    sequenceGridsRepository.Insert(gridInSequence);
                    logger.LogInfo(SequenceManagementPermissions.Update, "Grid '{0}' has been added.", gridS.First(g => g.Id == gridInSequence.GridId).Name);
                }
            }

            Load();
        }

        public void RemoveGridFromSequence()
        {
            view.RemoveSelectedItems(view.LvGrids);
        }

        public void DeleteSequence()
        {
            if (view.CbSequences.SelectedItem is Database.Models.Sequence sequence)
            {
                if (!ShowConfirm("Are you sure you want to delete this sequence?", Decide.No))
                {
                    return;
                }

                sequenceRepository.Delete(sequence.Id);
                logger.LogInfo(SequenceManagementPermissions.Delete, "Sequence '{0}' has been deleted.", sequence.Name);
                Load();
            }
            else
            {
                ShowError("No sequence has been selected.");
            }
        }

        public void MoveGridsDown()
        {
            BaseView.MoveSelectedItems(view.LvGrids, true);
        }

        public void MoveGridsUp()
        {
            BaseView.MoveSelectedItems(view.LvGrids, false);
        }

        public override void Load()
        {
            view.CbSequences.AddItems(sequenceRepository.SelectAll());
            view.CbGrids.AddItemsAndSelectFirst(gridRepository.SelectAll());
        }

        public void GetSequenceGrids()
        {
            if (view.CbSequences.SelectedItem is Database.Models.Sequence sequence)
            {
                view.TbSequenceName.Text = sequence.Name;
                var gridsInSequence = sequenceGridsRepository.SelectWhere(new { SequenceId = sequence.Id });
                view.LvGrids.Items.Clear();
                foreach (var gridInSequence in gridsInSequence)
                {
                    AddGridToListView(gridInSequence);
                }
            }
        }
    }
}
