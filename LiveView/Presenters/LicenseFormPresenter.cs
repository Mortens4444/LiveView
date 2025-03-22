using Database.Interfaces;
using LiveView.Core.Services;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using System.Linq;

namespace LiveView.Presenters
{
    public class LicenseFormPresenter : BasePresenter
    {
        private ILicenseFormView view;
        private readonly ILogger<LicenseForm> logger;
        private readonly IUserRepository userRepository;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;

        public LicenseFormPresenter(FormFactory formFactory, IGeneralOptionsRepository generalOptionsRepository, IUserRepository userRepository,
            IServerRepository serverRepository, ICameraRepository cameraRepository, ILogger<LicenseForm> logger)
            : base(generalOptionsRepository, formFactory)
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.serverRepository = serverRepository;
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
            var servers = serverRepository.SelectAll();
            var cameras = cameraRepository.SelectAll();
            var dedicatedServerIds = servers.Where(server => server.SerialNumber != null).Select(server => server.Id).ToList();
            var notDedicatedServerIds = servers.Where(server => server.SerialNumber == null).Select(server => server.Id).ToList();

            dynamic hardwareKey = Globals.HardwareKey;
            view.SetLabelText(view.LblLicenseStatusResult, hardwareKey.VideoSupervisorLicenseStatus ? Lng.Elem("Licensed") : Lng.Elem("Not licensed"));
            view.SetLabelText(view.LblId, hardwareKey.SziltechId);
            view.SetLabelText(view.LblUsersMaxPerAct, $"{hardwareKey.LiveViewUserNumber} / {users.Count}");
            view.SetLabelText(view.LblValidatedServersMaxPerAct, $"{hardwareKey.LiveViewSziltechServerNumber} / {dedicatedServerIds.Count}");
            view.SetLabelText(view.LblValidatedCamerasMaxPerAct, $"{hardwareKey.LiveViewSziltechCameraNumber} / {cameras.Count(camera => dedicatedServerIds.Contains(camera.ServerId) )}");
            view.SetLabelText(view.LblNotValidatedServersMaxPerAct, $"{hardwareKey.LiveViewOtherServerNumber} / {notDedicatedServerIds.Count}");
            view.SetLabelText(view.LblNotValidatedCamerasMaxPerAct, $"{hardwareKey.LiveViewOtherCameraNumber} / {cameras.Count(camera => notDedicatedServerIds.Contains(camera.ServerId))}");
        }
    }
}
