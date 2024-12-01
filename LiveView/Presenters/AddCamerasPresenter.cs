using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.VideoServer;
using LiveView.Services.VideoServer;
using Microsoft.Extensions.Logging;
using Mtf.Enums.Camera;
using Mtf.LanguageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class AddCamerasPresenter : BasePresenter
    {
        private readonly IAddCamerasView addCamerasView;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly IServerRepository<Server> serverRepository;
        private readonly ILogger<AddCameras> logger;
        private const int CameraIconIndex = 0;

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
            var items = addCamerasView.GetItems(addCamerasView.ServerCameras);
            for (int i = 0; i < items.Count; i++)
            {
                if (!addCamerasView.CamerasToViewHasElementWithGuid(((VideoServerCamera)items[i].Tag).Guid))
                {
                    var item = (ListViewItem)items[i].Clone();
                    itemsToView.Add(item);
                }
            }
            addCamerasView.AddToItems(addCamerasView.CamerasToView, itemsToView.ToArray());
        }

        public void AddSelectedCamera()
        {
            var itemsToView = new List<ListViewItem>();
            var items = addCamerasView.GetSelectedItems(addCamerasView.ServerCameras);
            for (int i = 0; i < items.Count; i++)
            {
                if (!addCamerasView.CamerasToViewHasElementWithGuid(((VideoServerCamera)items[i].Tag).Guid))
                {
                    var item = (ListViewItem)items[i].Clone();
                    itemsToView.Add(item);
                }
            }
            addCamerasView.AddToItems(addCamerasView.CamerasToView, itemsToView.ToArray());
        }

        public void RemoveAllCamera()
        {
            addCamerasView.RemoveAllItem(addCamerasView.CamerasToView);
        }

        public void RemoveSelectedCamera()
        {
            addCamerasView.RemoveSelectedItems(addCamerasView.CamerasToView);
        }

        public void LoadServers()
        {
            var servers = serverRepository.GetAll();
            addCamerasView.AddItems(addCamerasView.Servers, servers);
            addCamerasView.SelectByIndex(addCamerasView.Servers);
        }

        public async Task GetCamerasAsync()
        {
            var server = addCamerasView.GetSelectedItem<Server>(addCamerasView.Servers);
            var connectionResult = await VideoServerConnector.ConnectAsync(addCamerasView.GetSelf() as IVideoServerView, server);
            if (connectionResult.ErrorCode == VideoServerErrorHandler.Success)
            {
                var items = new List<ListViewItem>();
                foreach (var camera in connectionResult.Cameras)
                {
                    items.Add(new ListViewItem(camera.Name, CameraIconIndex)
                    {
                        Tag = camera,
                        ToolTipText = camera.Guid
                    });
                }
                addCamerasView.AddToItems(addCamerasView.ServerCameras, items.ToArray());
            }
            else
            {
                addCamerasView.ShowError(Lng.Elem("Connection failed"), VideoServerErrorHandler.GetMessage(connectionResult.ErrorCode));
            }
        }

        public void SaveCameras()
        {
            var server = addCamerasView.GetSelectedItem<Server>(addCamerasView.Servers);
            cameraRepository.DeleteWhere(new { ServerId = server.Id });
            var cameras = addCamerasView.GetItems(addCamerasView.CamerasToView);
            var orderedCameras = cameras.Cast<ListViewItem>().OrderBy(camera => camera.Text).ToList();

            var items = addCamerasView.GetItems(addCamerasView.ServerCameras);
            foreach (ListViewItem camera in orderedCameras)
            {
                var videoServerCamera = (VideoServerCamera)camera.Tag;
                cameraRepository.Insert(new Camera
                {
                    CameraName = videoServerCamera.Name,
                    ServerId = server.Id,
                    Guid = videoServerCamera.Guid,
                    RecorderIndex = AddCamerasPresenter.GetRecorderIndex(items, videoServerCamera.Name)
                });
            }
            addCamerasView.Close();
        }

        private static int GetRecorderIndex(ListView.ListViewItemCollection items, string cameraName)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Text == cameraName)
                {
                    return i;
                }
            }
            throw new InvalidOperationException();
        }
    }
}
