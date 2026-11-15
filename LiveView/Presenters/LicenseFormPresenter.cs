using Database.Interfaces;
using LiveView.Core.Services;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using System;
using System.Linq;

namespace LiveView.Presenters
{
    public class LicenseFormPresenter : BasePresenter
    {
        private ILicenseFormView view;
        private readonly ILogger<LicenseForm> logger;
        private readonly IUserRepository userRepository;
        private readonly IVideoServerRepository videoServerRepository;
        private readonly ICameraRepository cameraRepository;

        public LicenseFormPresenter(FormFactory formFactory, IGeneralOptionsRepository generalOptionsRepository, IUserRepository userRepository,
            IVideoServerRepository videoServerRepository, ICameraRepository cameraRepository, ILogger<LicenseForm> logger)
            : base(generalOptionsRepository, formFactory)
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.videoServerRepository = videoServerRepository;
            this.cameraRepository = cameraRepository;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ILicenseFormView;
        }

        public void Upgrade()
        {
            if (ShowDialog<UpgradeForm>())
            {
                Load();
            }
        }

        public override void Load()
        {
            var users = userRepository.SelectAll();
            var videoServers = videoServerRepository.SelectAll();
            var cameras = cameraRepository.SelectAll();
            var dedicatedVideoServerIds = videoServers.Where(videoServer => videoServer.SerialNumber != null).Select(videoServer => videoServer.Id).ToList();
            var notDedicatedVideoServerIds = videoServers.Where(videoServer => videoServer.SerialNumber == null).Select(videoServer => videoServer.Id).ToList();

            dynamic hardwareKey = Globals.HardwareKey;
            view.SetLabelText(view.LblLicenseStatusResult, hardwareKey.VideoSupervisorLicenseStatus ? Lng.Elem("Licensed") : Lng.Elem("Not licensed"));
            view.SetLabelText(view.LblId, hardwareKey.SziltechId);
            view.SetLabelText(view.LblUsersMaxPerAct, $"{GetStr(hardwareKey.LiveViewUserNumber)} / {users.Count}");
            view.SetLabelText(view.LblValidatedServersMaxPerAct, $"{GetStr(hardwareKey.LiveViewSziltechServerNumber)} / {dedicatedVideoServerIds.Count}");
            view.SetLabelText(view.LblValidatedCamerasMaxPerAct, $"{GetStr(hardwareKey.LiveViewSziltechCameraNumber)} / {cameras.Count(camera => dedicatedVideoServerIds.Contains(camera.VideoServerId))}");
            view.SetLabelText(view.LblNotValidatedServersMaxPerAct, $"{GetStr(hardwareKey.LiveViewOtherServerNumber)} / {notDedicatedVideoServerIds.Count}");
            view.SetLabelText(view.LblNotValidatedCamerasMaxPerAct, $"{GetStr(hardwareKey.LiveViewOtherCameraNumber)} / {cameras.Count(camera => notDedicatedVideoServerIds.Contains(camera.VideoServerId))}");
        }

        private static string GetStr(ushort value)
        {
            if (value == UInt16.MaxValue)
            {
                return Lng.Elem("Unlimited");
            }

            return value.ToString();
        }
    }
}
