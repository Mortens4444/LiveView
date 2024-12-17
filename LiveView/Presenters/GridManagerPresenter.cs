using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class GridManagerPresenter : BasePresenter
    {
        private readonly IGridManagerView view;
        private readonly IGridRepository<Grid> gridRepository;
        private readonly ILogger<GridManager> logger;

        public GridManagerPresenter(IGridManagerView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IGridRepository<Grid> gridRepository, ILogger<GridManager> logger, FormFactory formFactory)
            : base(view, generalOptionsRepository, formFactory)
        {
            this.view = view;
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
