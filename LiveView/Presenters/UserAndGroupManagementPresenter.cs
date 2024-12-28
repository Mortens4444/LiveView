using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes.Enums;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class UserAndGroupManagementPresenter : BasePresenter
    {
        private IUserAndGroupManagementView view;
        private readonly IUserRepository<User> userRepository;
        private readonly IGroupRepository<Group> groupRepository;
        private readonly IUsersInGroupsRepository<UserGroup> userGroupRepository;
        private readonly ILogger<UserAndGroupManagement> logger;
        private readonly PermissionManager permissionManager;
        
        private const int GroupIconIndex = 0;
        private const int UserIconIndex = 1;

        public UserAndGroupManagementPresenter(UserAndGroupManagementPresenterDependencies userAndGroupManagementPresenterDependencies)
            : base(userAndGroupManagementPresenterDependencies)
        {
            permissionManager = userAndGroupManagementPresenterDependencies.PermissionManager;
            userRepository = userAndGroupManagementPresenterDependencies.UserRepository;
            groupRepository = userAndGroupManagementPresenterDependencies.GroupRepository;
            userGroupRepository = userAndGroupManagementPresenterDependencies.UserGroupRepository;
            logger = userAndGroupManagementPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IUserAndGroupManagementView;
        }

        public void Delete()
        {
            if (!ShowConfirm("Are you sure you want to delete this item?", Decide.No))
            {
                return;
            }

            var node = view.GetSelectedItem(view.TvUsersAndGroups);
            if (node != null)
            {
                if (node.Tag is Group group)
                {
                    if (permissionManager.CurrentUser.HasPermission(ServerManagementPermissions.Delete))
                    {
                        groupRepository.Delete(group.Id);
                        logger.LogInfo("Group '{0}' has been deleted.", group);
                    }
                    else
                    {
                        logger.LogError("User '{0}' has no permission to delete group.", permissionManager.CurrentUser);
                        throw new UnauthorizedAccessException();
                    }
                }
                else if (node.Tag is User user)
                {
                    if (permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Delete))
                    {
                        userRepository.Delete(user.Id);
                        logger.LogInfo("User '{0}' has been deleted.", user);
                    }
                    else
                    {
                        logger.LogError("User '{0}' has no permission to delete user.", permissionManager.CurrentUser);
                        throw new UnauthorizedAccessException();
                    }
                }
                Load();
            }
        }

        public override void Load()
        {
            var groups = groupRepository.GetAll();
            var users = userRepository.GetAll();
            var usersInGroups = userGroupRepository.GetAll();

            var groupTreeNodes = new List<TreeNode>();
            foreach (var group in groups)
            {
                var groupTreeNode = new TreeNode(group.Name, GroupIconIndex, GroupIconIndex)
                {
                    Name = group.Id.ToString(),
                    Tag = group,
                    ToolTipText = group.OtherInformation
                };

                var usersOfGroup = usersInGroups.Where(user => user.GroupId == group.Id);
                foreach (var userOfGroup in usersOfGroup)
                {
                    var user = users.FirstOrDefault(u => u.Id == userOfGroup.UserId);
                    var userTreeNode = new TreeNode(user.Username, UserIconIndex, UserIconIndex)
                    {
                        Name = $"User_{user.Id}",
                        Tag = user,
                        ToolTipText = user.ToString()
                    };
                    groupTreeNode.Nodes.Add(userTreeNode);
                }

                groupTreeNodes.Add(groupTreeNode);
            }

            var groupsNode = view.TvUsersAndGroups.Nodes["Groups"];
            groupsNode.Nodes.Clear();
            view.AddNodes(groupsNode, groupTreeNodes);
            view.ExpandAll(groupsNode);
        }

        public void Modify()
        {
            var node = view.GetSelectedItem(view.TvUsersAndGroups);
            if (node != null)
            {
                if (node.Tag is Group group)
                {
                    if (permissionManager.CurrentUser.HasPermission(ServerManagementPermissions.Update))
                    {
                        if (ShowDialog<AddGroup>(group))
                        {
                            logger.LogInfo("Group '{0}' has been modified.", group);
                        }
                    }
                    else
                    {
                        logger.LogError("User '{0}' has no permission to modify group.", permissionManager.CurrentUser);
                        throw new UnauthorizedAccessException();
                    }
                }
                else if (node.Tag is User user)
                {
                    if (permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Update))
                    {
                        if (ShowDialog<AddUser>(user))
                        {
                            logger.LogInfo("User '{0}' has been modified.", user);
                        }
                    }
                    else
                    {
                        logger.LogError("User '{0}' has no permission to modify user.", permissionManager.CurrentUser);
                        throw new UnauthorizedAccessException();
                    }
                }
                Load();
            }
        }
    }
}
