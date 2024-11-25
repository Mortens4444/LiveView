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
    public partial class AddGroup : Form, IAddGroupView
    {
        private readonly AddGroupPresenter addGroupPresenter;

        public AddGroup(PermissionManager permissionManager, ILogger<AddGroup> logger, IGroupRepository<Group> groupRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            addGroupPresenter = new AddGroupPresenter(this, groupRepository, logger);

            Translator.Translate(this);
        }
    }
}
