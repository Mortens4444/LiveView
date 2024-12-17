using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LicenseForm : BaseView, ILicenseFormView
    {
        private readonly LicenseFormPresenter presenter;

        public LicenseForm(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository,
            IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository, ILogger<LicenseForm> logger)
            : base(permissionManager)
        {
            InitializeComponent();

            presenter = new LicenseFormPresenter(this, generalOptionsRepository, userRepository, serverRepository, cameraRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        public Label LblLicenseStatusResult => lblLicenseStatusResult;

        public Label LblId => lblId;

        public Label LblUsersMaxPerAct => lblUsersMaxPerAct;

        public Label LblValidatedServersMaxPerAct => lblValidatedServersMaxPerAct;

        public Label LblValidatedCamerasMaxPerAct => lblValidatedCamerasMaxPerAct;

        public Label LblNotValidatedServersMaxPerAct => lblNotValidatedServersMaxPerAct;

        public Label LblNotValidatedCamerasMaxPerAct => lblNotValidatedCamerasMaxPerAct;

        private void BtnUpgrade_Click(object sender, EventArgs e)
        {
            presenter.Upgrade();
        }

        private void LicenseForm_Shown(object sender, EventArgs e)
        {
            presenter.Load();
        }
    }
}
