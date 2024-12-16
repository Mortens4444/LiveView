using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class EnterPass : BaseView, IEnterPassView
    {
        private readonly EnterPassPresenter presenter;

        public EnterPass(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<EnterPass> logger, IUserRepository<User> userRepository) : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new EnterPassPresenter(this, generalOptionsRepository, userRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(DatabaseServerManagementPermissions.FullControl)]
        private void BtnOK_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Login();
        }
    }
}
