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
    public partial class EnterPass : Form, IEnterPassView
    {
        private readonly EnterPassPresenter enterPassPresenter;

        public EnterPass(PermissionManager permissionManager, ILogger<EnterPass> logger, IUserRepository<User> userRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            enterPassPresenter = new EnterPassPresenter(this, userRepository, logger);

            Translator.Translate(this);
        }
    }
}
