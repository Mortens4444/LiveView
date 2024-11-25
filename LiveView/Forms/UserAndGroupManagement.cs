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
    public partial class UserAndGroupManagement : Form, IUserAndGroupManagementView
    {
        private readonly UserAndGroupManagementPresenter userAndGroupManagementPresenter;

        public UserAndGroupManagement(PermissionManager permissionManager, ILogger<UserAndGroupManagement> logger, IUserRepository<User> userRepository, IGroupRepository<Group> groupRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            userAndGroupManagementPresenter = new UserAndGroupManagementPresenter(this, userRepository, groupRepository, logger);

            Translator.Translate(this);
        }
    }
}
