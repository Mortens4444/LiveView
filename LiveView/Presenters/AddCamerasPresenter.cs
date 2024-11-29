using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.VideoServer;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class AddCamerasPresenter : BasePresenter
    {
        private readonly IAddCamerasView addCamerasView;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly IServerRepository<Server> serverRepository;
        private readonly ILogger<AddCameras> logger;

        public AddCamerasPresenter(IAddCamerasView addCamerasView, ICameraRepository<Camera> cameraRepository, IServerRepository<Server> serverRepository, ILogger<AddCameras> logger)
            : base(addCamerasView)
        {
            this.addCamerasView = addCamerasView;
            this.cameraRepository = cameraRepository;
            this.serverRepository = serverRepository;
            this.logger = logger;
        }

        public void AddAllCamera()
        {
            var itemsToView = new List<ListViewItem>();
            var items = addCamerasView.GetServerCameras();
            for (int i = 0; i < items.Count; i++)
            {
                if (!addCamerasView.CamerasToViewHasElementWithGuid(((VideoServerCamera)items[i].Tag).Guid))
                {
                    var item = (ListViewItem)items[i].Clone();
                    itemsToView.Add(item);
                }
            }
            addCamerasView.AddToItemsToView(itemsToView.ToArray());
        }

        public void AddSelectedCamera()
        {
            var itemsToView = new List<ListViewItem>();
            var items = addCamerasView.GetServerSelectedCameras();
            for (int i = 0; i < items.Count; i++)
            {
                if (!addCamerasView.CamerasToViewHasElementWithGuid(((VideoServerCamera)items[i].Tag).Guid))
                {
                    var item = (ListViewItem)items[i].Clone();
                    itemsToView.Add(item);
                }
            }
            addCamerasView.AddToItemsToView(itemsToView.ToArray());
        }

        public void RemoveAllCamera()
        {
            addCamerasView.RemoveAllCamera();
        }

        public void RemoveSelectedCamera()
        {
            addCamerasView.RemoveSelectedCamera();
        }

        public void LoadServers()
        {
            var servers = serverRepository.GetAll();
            addCamerasView.LoadServers(servers);
        }

        public void GetCameras()
        {
            addCamerasView.GetCameras();
        }
    }
}
