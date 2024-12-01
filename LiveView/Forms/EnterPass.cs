using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

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

        private void Btn_OK_Click(object sender, EventArgs e)
        {

        }
    }
}
