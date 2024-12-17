using Database.Interfaces;
using Database.Models;
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
        private readonly ILicenseFormView view;
        private readonly ILogger<LicenseForm> logger;
        private readonly IUserRepository<User> userRepository;
        private readonly IServerRepository<Server> serverRepository;
        private readonly ICameraRepository<Camera> cameraRepository;

        public LicenseFormPresenter(ILicenseFormView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository,
            IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository, ILogger<LicenseForm> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.logger = logger;
            this.userRepository = userRepository;
            this.serverRepository = serverRepository;
            this.cameraRepository = cameraRepository;
        }

        public void Upgrade()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            var users = userRepository.GetAll();
            var servers = serverRepository.GetAll();
            var cameras = cameraRepository.GetAll();
            var dedicatedServerIds = servers.Where(server => server.SerialNumber != null).Select(server => server.Id).ToList();
            var notDedicatedServerIds = servers.Where(server => server.SerialNumber == null).Select(server => server.Id).ToList();

            dynamic hardwareKey = MainForm.HardwareKey;
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
