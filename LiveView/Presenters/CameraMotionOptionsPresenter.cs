using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class CameraMotionOptionsPresenter : BasePresenter
    {
        private ICameraMotionSettingsView view;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ILogger<CameraMotionSettings> logger;

        public CameraMotionOptionsPresenter(CameraMotionOptionsPresenterDependencies cameraMotionOptionsPresenterDependencies)
            : base(cameraMotionOptionsPresenterDependencies)
        {
            serverRepository = cameraMotionOptionsPresenterDependencies.ServerRepository;
            cameraRepository = cameraMotionOptionsPresenterDependencies.CameraRepository;
            logger = cameraMotionOptionsPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ICameraMotionSettingsView;
        }

        public void SaveSettings()
        {
            var items = view.LvCameras.SelectedItems;
            foreach (ListViewItem item in items)
            {
                if (item.Tag is Camera camera && view.CbPartnerCamera.SelectedItem is Camera partnerCamera)
                {
                    camera.PartnerCameraId = partnerCamera.Id;
                    camera.MotionTrigger = (long)view.NudMotionTrigger.Value;
                    camera.MotionTriggerMinimumLength = (long)view.NudMotionTriggerMinimumLength.Value;
                    cameraRepository.Update(camera);
                }
            }
            Load();
        }

        public override void Load()
        {
            var servers = serverRepository.SelectAll();
            view.AddItems(view.CbPartnerVideoServer, servers);

            var cameras = cameraRepository.SelectAll();
            view.AddItems(view.CbPartnerCamera, cameras);

            view.LvCameras.AddItems(cameras, (Camera camera) =>
            {
                var server = servers.First(s => s.Id == camera.ServerId);
                var partnerCamera = cameras.FirstOrDefault(c => c.Id == camera.PartnerCameraId);
                var partnerServer = partnerCamera != null ? servers.FirstOrDefault(s => s.Id == partnerCamera.ServerId) : null;
                var result = new ListViewItem(server.Hostname)
                {
                    Tag = camera
                };
                result.SubItems.Add(camera.CameraName);
                result.SubItems.Add(camera.MotionTrigger?.ToString() ?? String.Empty);
                result.SubItems.Add(camera.MotionTriggerMinimumLength?.ToString() ?? String.Empty);
                result.SubItems.Add(partnerCamera != null ? $"{partnerServer.Hostname} - {partnerCamera.CameraName}" : String.Empty);
                return result;
            });
        }

        public void ClearMotionSettings()
        {
            var items = view.LvCameras.SelectedItems;
            foreach (ListViewItem item in items)
            {
                if (item.Tag is Camera camera)
                {
                    camera.PartnerCameraId = null;
                    camera.MotionTrigger = null;
                    camera.MotionTriggerMinimumLength = null;
                    cameraRepository.Update(camera);
                }
            }
            Load();
        }
    }
}
