using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class GridManagerPresenter : BasePresenter
    {
        private IGridManagerView view;
        private readonly IGridRepository<Grid> gridRepository;
        private readonly IGridCameraRepository<GridCamera> gridCameraRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly IServerRepository<Server> serverRepository;
        private readonly ILogger<GridManager> logger;

        public GridManagerPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IGridRepository<Grid> gridRepository, IGridCameraRepository<GridCamera> gridCameraRepository,
            ICameraRepository<Camera> cameraRepository, IServerRepository<Server> serverRepository,
            ILogger<GridManager> logger, FormFactory formFactory)
            : base(generalOptionsRepository, formFactory)
        {
            this.gridRepository = gridRepository;
            this.gridCameraRepository = gridCameraRepository;
            this.cameraRepository = cameraRepository;
            this.serverRepository = serverRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IGridManagerView;
        }

        public override void Load()
        {
            var grids = gridRepository.GetAll();
            view.CbGrids.AddItemsAndSelectFirst(grids);
        }

        public void DeleteGrid()
        {
            if (view.CbGrids.SelectedItem is Grid grid)
            {
                gridRepository.Delete(grid.Id);
            }
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
            var selectedGrid = view.CbGrids.SelectedItem;
            if (selectedGrid is Grid grid)
            {
                var gridCameras = gridCameraRepository.GetWhere(new { GridId = grid.Id });
                view.LvGridCameras.Items.Clear();
                foreach (var gridCamera in gridCameras)
                {
                    var camera = cameraRepository.Get(gridCamera.CameraId);
                    var server = serverRepository.Get(camera.ServerId);
                    
                    var item = new ListViewItem((view.LvGridCameras.Items.Count + 1).ToString());
                    item.SubItems.Add(camera.CameraName);
                    item.SubItems.Add(server.Hostname);
                    item.SubItems.Add(camera.Guid);
                    view.LvGridCameras.Items.Add(item);
                }
            }
        }
    }
}
