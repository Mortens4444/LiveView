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
    public partial class AddGroup : BaseView, IAddGroupView
    {
        private readonly AddGroupPresenter addGroupPresenter;
        private readonly PermissionManager permissionManager;

        public AddGroup(PermissionManager permissionManager, ILogger<AddGroup> logger, IGroupRepository<Group> groupRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            addGroupPresenter = new AddGroupPresenter(this, groupRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(GroupManagementPermissions.Create)]
        [RequirePermission(GroupManagementPermissions.Update)]
        private void Btn_CreateOrModifyGroup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGroupPresenter.CreateOrModifyGroup();
        }
    }
}
