using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Presenters
{
    public class GridManagerPresenter : BasePresenter
    {
        private readonly IGridManagerView gridManagerView;
        private readonly IGridRepository<Grid> gridRepository;
        private readonly ILogger<GridManager> logger;

        public GridManagerPresenter(IGridManagerView gridManagerView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IGridRepository<Grid> gridRepository, ILogger<GridManager> logger, FormFactory formFactory)
            : base(gridManagerView, generalOptionsRepository, formFactory)
        {
            this.gridManagerView = gridManagerView;
            this.gridRepository = gridRepository;
            this.logger = logger;
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public void DeleteGrid()
        {
            throw new NotImplementedException();
        }

        public void ModifyGrid()
        {
            throw new NotImplementedException();
        }

        public void MoveDownCamera()
        {
            throw new NotImplementedException();
        }

        public void MoveUpCamera()
        {
            throw new NotImplementedException();
        }

        public void SelectGrid()
        {
            throw new NotImplementedException();
        }
    }
}
