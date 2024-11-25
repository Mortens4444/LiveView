using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class Profile : Form, IProfileView
    {
        private readonly ProfilePresenter profilePresenter;

        public Profile(PermissionManager permissionManager, ILogger<Profile> logger, IUserRepository<User> userRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            profilePresenter = new ProfilePresenter(this, userRepository, logger);

            Translator.Translate(this);
        }
    }
}
