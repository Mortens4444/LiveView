using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class AddGridPresenter : BasePresenter
    {
        private readonly IAddGridView addGridView;
        private readonly IGridRepository<Grid> gridRepository;
        private readonly ILogger<AddGrid> logger;

        public AddGridPresenter(IAddGridView addGridView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IGridRepository<Grid> gridRepository, ILogger<AddGrid> logger)
            : base(addGridView, generalOptionsRepository)
        {
            this.addGridView = addGridView;
            this.gridRepository = gridRepository;
            this.logger = logger;
        }

        public void AdjustLeftEdgeLeftwards()
        {
            throw new NotImplementedException();
        }

        public void AdjustLeftEdgeRightwards()
        {
            throw new NotImplementedException();
        }

        public void AdjustLowerEdgeDownwards()
        {
            throw new NotImplementedException();
        }

        public void AdjustLowerEdgeUpwards()
        {
            throw new NotImplementedException();
        }

        public void AdjustRightEdgeLeftwards()
        {
            throw new NotImplementedException();
        }

        public void AdjustRightEdgeRightwards()
        {
            throw new NotImplementedException();
        }

        public void AdjustUpperEdgeDownwards()
        {
            throw new NotImplementedException();
        }

        public void AdjustUpperEdgeUpwards()
        {
            throw new NotImplementedException();
        }

        public void CombineOnGrid()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate10Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate16Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate1Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate25Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate36Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate49Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate4Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate64Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate6Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate7Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate8Way()
        {
            throw new NotImplementedException();
        }

        public void LoadTemplate9Way()
        {
            throw new NotImplementedException();
        }

        public void SaveGrid()
        {
            throw new NotImplementedException();
        }

        public void SetHeightForAspect16_10()
        {
            throw new NotImplementedException();
        }

        public void SetHeightForAspect16_9()
        {
            throw new NotImplementedException();
        }

        public void SetHeightForAspect4_3()
        {
            throw new NotImplementedException();
        }

        public void SetWidthForAspect16_10()
        {
            throw new NotImplementedException();
        }

        public void SetWidthForAspect16_9()
        {
            throw new NotImplementedException();
        }

        public void SetWidthForAspect4_3()
        {
            throw new NotImplementedException();
        }
    }
}
