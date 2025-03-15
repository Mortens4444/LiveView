using Database.Enums;
using Database.Interfaces;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.Permissions.Enums;
using System;
using System.Linq;

namespace LiveView.Presenters
{
    public class CameraPropertiesPresenter : BasePresenter
    {
        private ICameraPropertiesView view;
        private readonly ICameraRepository cameraRepository;
        private readonly ILogger<CameraProperties> logger;

        public CameraPropertiesPresenter(CameraPropertiesPresenterDependencies dependencies)
            : base(dependencies)
        {
            cameraRepository = dependencies.CameraRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ICameraPropertiesView;
        }

        public void Save()
        {
            view.Camera.IpAddress = view.TbCameraIpAddress.Text;
            view.Camera.Username = view.TbCameraUsername.Text;
            view.Camera.Password = view.TbCameraPassword.Password;
            view.Camera.HttpStreamUrl = view.TbHttpStream.Text;
            view.Camera.StreamId = (int)view.NudStreamId.Value;
            view.Camera.FullscreenMode = (CameraMode)Enum.Parse(typeof(CameraMode), view.CbFullscreenMode.SelectedItem.ToString());

            cameraRepository.Update(view.Camera);
            logger.LogInfo(CameraManagementPermissions.Update, "Camera '{0}' properties has been changed.", view.Camera.CameraName);
        }

        public override void Load()
        {
            var fullscreenModes = Database.Extensions.EnumExtensions.GetEnabledValues<CameraMode>()
                .Select(mode => Lng.Elem(mode.GetDescription()));
            view.AddItems(view.CbFullscreenMode, fullscreenModes);

            view.TbCameraName.Text = view.Camera.CameraName;
            view.TbCameraGuid.Text = view.Camera.Guid;
            view.TbCameraIpAddress.Text = view.Camera.IpAddress;
            view.TbCameraUsername.Text = view.Camera.Username;
            view.TbCameraPassword.Password = view.Camera.Password;
            view.TbHttpStream.Text = view.Camera.HttpStreamUrl;
            view.NudStreamId.Value = view.Camera.StreamId ?? 0;
            if (Enum.TryParse(view.Camera.FullscreenMode.ToString(), out CameraMode cameraMode))
            {
                view.CbFullscreenMode.SelectedItem = cameraMode.ToString();
            }
            else
            {
                view.CbFullscreenMode.SelectedIndex = 0;
            }
        }

        public void ShowSearchCameraUrlForm()
        {
            ShowForm<SearchCameraUrlForm>();
        }
    }
}
