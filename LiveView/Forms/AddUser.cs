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
    public partial class AddUser : Form, IAddUserView
    {
        private readonly AddUserPresenter addUserPresenter;

        public AddUser(PermissionManager permissionManager, ILogger<AddUser> logger, IUserRepository<User> userRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            addUserPresenter = new AddUserPresenter(this, userRepository, logger);

            Translator.Translate(this);
        }
    }
}
