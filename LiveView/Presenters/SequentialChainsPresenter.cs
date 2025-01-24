using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes.Enums;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class SequentialChainsPresenter : BasePresenter
    {
        private ISequentialChainsView view;
        private readonly IGridRepository gridRepository;
        private readonly ISequenceRepository sequenceRepository;
        private readonly IGridInSequenceRepository gridInSequenceRepository;
        private readonly ILogger<SequentialChains> logger;

        public SequentialChainsPresenter(SequentialChainsPresenterDependencies sequentialChainsPresenterDependencies)
            : base(sequentialChainsPresenterDependencies)
        {
            gridRepository = sequentialChainsPresenterDependencies.GridRepository;
            sequenceRepository = sequentialChainsPresenterDependencies.SequenceRepository;
            gridInSequenceRepository = sequentialChainsPresenterDependencies.GridInSequenceRepository;
            logger = sequentialChainsPresenterDependencies.Logger;
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

        private void AddGridToListView(GridInSequence gridInSequence)
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
            long? sequenceId = null;
            var sequence = view.GetSequence();
            if (sequence.Id == 0)
            {
                sequenceId = sequenceRepository.InsertAndReturnId<long>(sequence);
            }
            else
            {
                sequenceRepository.Update(sequence);
            }

            foreach (ListViewItem item in view.LvGrids.Items)
            {
                var gridInSequence = item.Tag as GridInSequence;
                if (gridInSequence != null)
                {
                    if (sequenceId != null)
                    {
                        gridInSequence.SequenceId = sequenceId.Value;
                        gridInSequenceRepository.Insert(gridInSequence);
                    }
                    else
                    {
                        gridInSequenceRepository.Update(gridInSequence);
                    }
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
            if (!ShowConfirm("Are you sure you want to delete this item?", Decide.No))
            {
                return;
            }

            if (view.CbSequences.SelectedItem is Database.Models.Sequence sequence)
            {
                sequenceRepository.Delete(sequence.Id);
                Load();
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
                var gridsInSequence = gridInSequenceRepository.SelectWhere(new { SequenceId = sequence.Id });
                view.LvGrids.Items.Clear();
                foreach (var gridInSequence in gridsInSequence)
                {
                    AddGridToListView(gridInSequence);
                }
            }
        }
    }
}
