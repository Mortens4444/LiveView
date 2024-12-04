using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class EnterPass : BaseView, IEnterPassView
    {
        private readonly EnterPassPresenter enterPassPresenter;
        private readonly PermissionManager permissionManager;

        public EnterPass(PermissionManager permissionManager, ILogger<EnterPass> logger, IUserRepository<User> userRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            enterPassPresenter = new EnterPassPresenter(this, userRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(DatabaseServerManagementPermissions.FullControl)]
        private void BtnOK_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            enterPassPresenter.Login();
        }
    }
}
