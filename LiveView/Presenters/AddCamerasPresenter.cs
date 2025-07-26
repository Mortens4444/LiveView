using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Models.VideoServer;
using LiveView.Services.VideoServer;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.Permissions.Enums;
using Mtf.Windows.Forms.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIDEOCONTROL4Lib;
using VideoServer = Database.Models.VideoServer;

namespace LiveView.Presenters
{
    public class AddCamerasPresenter : BasePresenter
    {
        private IAddCamerasView view;
        private readonly ICameraRepository cameraRepository;
        private readonly IVideoServerRepository videoServerRepository;
        private readonly ILogger<AddCameras> logger;
        private const int CameraIconIndex = 0;

        public AddCamerasPresenter(AddCamerasPresenterDependencies dependencies)
            : base(dependencies)
        {
            cameraRepository = dependencies.CameraRepository;
            videoServerRepository = dependencies.VideoServerRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddCamerasView;
        }

        public void AddAllCamera()
        {
            AddAllItemsFromListViewToAnother(view.ServerCameras, view.CamerasToView, (item) => view.CamerasToViewHasElementWithGuid(((VideoServerCamera)item.Tag).Guid));
        }

        public void AddSelectedCamera()
        {
            AddSelectedItemsFromListViewToAnother(view.ServerCameras, view.CamerasToView, (item) => view.CamerasToViewHasElementWithGuid(((VideoServerCamera)item.Tag).Guid));
        }

        public void RemoveAllCamera()
        {
            view.RemoveAllItem(view.CamerasToView);
        }

        public void RemoveSelectedCamera()
        {
            view.RemoveSelectedItems(view.CamerasToView);
        }

        public void LoadServers(VideoServer videoServer)
        {
            var videoServers = videoServerRepository.SelectAll();
            view.AddItems(view.VideoServers, videoServers);
            var index = videoServers.IndexOf(videoServer);
            view.SelectByIndex(view.VideoServers, index);
        }

        public async Task GetCamerasAsync()
        {
            var server = view.GetSelectedItem<VideoServer>(view.VideoServers);
            var connectionTimeout = generalOptionsRepository.Get(Setting.MaximumTimeToWaitForAVideoServerIs, 500);
            var connectionResult = await VideoServerConnector.ConnectAsync(view.GetSelf<IVideoServerView>(), server, connectionTimeout);
            if (connectionResult.ErrorCode == VideoServerErrorHandler.Success)
            {
                view.ServerCameras.AddItems(connectionResult.Cameras, camera => new ListViewItem(camera.Name, CameraIconIndex)
                {
                    Tag = camera,
                    ToolTipText = camera.Guid
                });
            }
            else
            {
                //ShowError("Connection failed", VideoServerErrorHandler.GetMessage(connectionResult.ErrorCode));
                var videoServer = view.GetSelectedItem<VideoServer>(view.VideoServers);
                var newCamera = new Camera
                {
                    CameraName = Lng.Elem("Camera"),
                    VideoServerId = videoServer.Id,
                    Guid = Guid.NewGuid().ToString(),
                    RecorderIndex = -1
                };
                cameraRepository.Insert(newCamera);
                CloseForm();
            }
        }

        public void SaveCameras()
        {
            var videoServer = view.GetSelectedItem<VideoServer>(view.VideoServers);
            cameraRepository.DeleteCamerasOfVideoServer(videoServer.Id);
            var cameras = view.GetItems(view.CamerasToView);
            var orderedCameras = cameras.Cast<ListViewItem>().OrderBy(camera => camera.Text).ToList();

            var items = view.GetItems(view.ServerCameras);
            foreach (ListViewItem camera in orderedCameras)
            {
                var videoServerCamera = (VideoServerCamera)camera.Tag;
                var newCamera = new Camera
                {
                    CameraName = videoServerCamera.Name,
                    VideoServerId = videoServer.Id,
                    Guid = videoServerCamera.Guid,
                    RecorderIndex = GetRecorderIndex(items, videoServerCamera.Name)
                };
                cameraRepository.Insert(newCamera);
                logger.LogInfo(CameraManagementPermissions.Create, "Camera '{0}' has been added to the grid.", newCamera);
            }
            view.Close();
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
            throw new InvalidOperationException($"Unable to retrieve recorder index of camera: {cameraName}");
        }
    }
}
