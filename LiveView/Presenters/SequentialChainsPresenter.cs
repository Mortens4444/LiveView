using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class SequentialChainsPresenter : BasePresenter
    {
        private ISequentialChainsView view;
        private readonly IGridRepository<Grid> gridRepository;
        private readonly ISequenceRepository<Sequence> sequenceRepository;
        private readonly IGridInSequenceRepository<GridInSequence> gridInSequenceRepository;
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
            var item = new ListViewItem(gridInSequence.Number.ToString())
            {
                Tag = gridInSequence
            };
            item.SubItems.Add(gridInSequence.TimeToShow.ToString());
            var grid = gridRepository.Get(gridInSequence.GridId);
            item.SubItems.Add(grid.Name);
            view.LvGrids.Items.Add(item);
        }

        public void SaveSequence()
        {
            throw new NotImplementedException();
        }

        public void RemoveGridFromSequence()
        {
            view.RemoveSelectedItems(view.LvGrids);
        }

        public void DeleteSequence()
        {
            if (view.CbSequences.SelectedItem is Sequence sequence)
            {
                sequenceRepository.Delete(sequence.Id);
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
            var sequences = sequenceRepository.GetAll();
            view.AddItems(view.CbSequences, sequences);
            view.SelectByIndex(view.CbSequences);

            var grids = gridRepository.GetAll();
            view.AddItems(view.CbGrids, grids);
            view.SelectByIndex(view.CbGrids);
        }

        public void GetSequenceGrids()
        {
            if (view.CbSequences.SelectedItem is Sequence sequence)
            {
                var grids = gridInSequenceRepository.GetWhere(new { SequenceId = sequence.Id });
            }
        }
    }
}
