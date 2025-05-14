using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
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
        private readonly IUserRepository userRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IUsersInGroupsRepository userGroupRepository;
        private readonly ILogger<UserAndGroupManagement> logger;
        private readonly PermissionManager<User> permissionManager;
        
        private const int GroupIconIndex = 0;
        private const int UserIconIndex = 1;

        public UserAndGroupManagementPresenter(UserAndGroupManagementPresenterDependencies dependencies)
            : base(dependencies)
        {
            permissionManager = dependencies.PermissionManager;
            userRepository = dependencies.UserRepository;
            groupRepository = dependencies.GroupRepository;
            userGroupRepository = dependencies.UserGroupRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IUserAndGroupManagementView;
        }

        public void Delete()
        {
            var node = view.GetSelectedItem(view.TvUsersAndGroups);
            if (node != null)
            {
                if (node.Tag is Group group)
                {
                    if (!ShowConfirm("Are you sure you want to delete this group?", Decide.No))
                    {
                        return;
                    }

                    if (permissionManager.HasPermission(GroupManagementPermissions.Delete))
                    {
                        groupRepository.DeleteGroupPermissions(group.Id);
                        groupRepository.Delete(group.Id);
                        logger.LogInfo(GroupManagementPermissions.Delete, "Group '{0}' has been deleted.", group);
                    }
                    else
                    {
                        var message = Lng.FormattedElem("User '{0}' has no permission to delete group.", args: permissionManager.CurrentUser);
                        logger.LogError(message);
                        throw new UnauthorizedAccessException(message);
                    }
                }
                else if (node.Tag is User user)
                {
                    if (user.Id == permissionManager.CurrentUser.Tag.Id)
                    {
                        ShowError("The logged in user cannot be deleted.");
                        return;
                    }

                    if (!ShowConfirm("Are you sure you want to delete this user?", Decide.No))
                    {
                        return;
                    }

                    if (permissionManager.HasPermission(UserManagementPermissions.Delete))
                    {
                        userRepository.Delete(user.Id);
                        logger.LogInfo(UserManagementPermissions.Delete, "User '{0}' has been deleted.", user);
                    }
                    else
                    {
                        var message = Lng.FormattedElem("User '{0}' has no permission to delete user.", args: permissionManager.CurrentUser);
                        logger.LogError(message);
                        throw new UnauthorizedAccessException(message);
                    }
                }
                else
                {
                    ShowError("No item has been selected.");
                }
                Load();
            }
        }

        public override void Load()
        {
            var groups = groupRepository.SelectAll();
            var users = userRepository.SelectAll();
            var usersInGroups = userGroupRepository.SelectAll();

            var userInGroupIds = usersInGroups
                .Where(ug => ug.UserId == permissionManager.CurrentUser.Tag.Id)
                .Select(ug => ug.GroupId);

            var userGroups = groups.Where(g => userInGroupIds.Contains(g.Id)).ToList();

            var groupTreeNodes = userGroups
                .Select(group => CreateGroupTreeNode(group, groups, users, usersInGroups))
                .ToList();

            var groupsNode = view.TvUsersAndGroups.Nodes["Groups"];
            groupsNode.Nodes.Clear();
            view.AddNodes(groupsNode, groupTreeNodes);
            view.TvUsersAndGroups.ExpandAll();
            view.ExpandAll(groupsNode);
        }

        private TreeNode CreateGroupTreeNode(Group group, IEnumerable<Group> allGroups, IEnumerable<User> allUsers, IEnumerable<UserGroup> allUsersInGroups)
        {
            var groupNode = new TreeNode(group.Name, GroupIconIndex, GroupIconIndex)
            {
                Name = group.Id.ToString(),
                Tag = group,
                ToolTipText = group.OtherInformation
            };

            AddUsersToGroupNode(group, allUsers, allUsersInGroups, groupNode);
            AddChildGroups(group, allGroups, allUsers, allUsersInGroups, groupNode);

            return groupNode;
        }

        private void AddChildGroups(Group group, IEnumerable<Group> allGroups, IEnumerable<User> allUsers, IEnumerable<UserGroup> allUsersInGroups, TreeNode groupNode)
        {
            var childGroups = allGroups.Where(g => g.ParentGroupId == group.Id);
            foreach (var childGroup in childGroups)
            {
                var childGroupNode = CreateGroupTreeNode(childGroup, allGroups, allUsers, allUsersInGroups);
                groupNode.Nodes.Add(childGroupNode);
            }
        }

        private static void AddUsersToGroupNode(Group group, IEnumerable<User> allUsers, IEnumerable<UserGroup> allUsersInGroups, TreeNode groupNode)
        {
            var usersOfGroup = allUsersInGroups.Where(ug => ug.GroupId == group.Id);
            foreach (var userOfGroup in usersOfGroup)
            {
                var user = allUsers.FirstOrDefault(u => u.Id == userOfGroup.UserId);
                if (user != null)
                {
                    var userNode = new TreeNode(user.Username, UserIconIndex, UserIconIndex)
                    {
                        Name = $"User_{user.Id}",
                        Tag = user,
                        ToolTipText = user.ToString()
                    };
                    groupNode.Nodes.Add(userNode);
                }
            }
        }

        public void Modify()
        {
            var node = view.GetSelectedItem(view.TvUsersAndGroups);
            if (node != null)
            {
                if (node.Tag is Group group)
                {
                    if (permissionManager.HasPermission(GroupManagementPermissions.Update))
                    {
                        if (group.ParentGroupId.HasValue)
                        {
                            var parentGroup = groupRepository.Select(group.ParentGroupId.Value);
                            if (ShowDialog<AddGroup>(parentGroup, group))
                            {
                                logger.LogInfo(GroupManagementPermissions.Update, "Group '{0}' has been modified.", group);
                            }
                        }
                    }
                    else
                    {
                        var message = Lng.FormattedElem("User '{0}' has no permission to modify group.", args: permissionManager.CurrentUser);
                        logger.LogError(message);
                        throw new UnauthorizedAccessException(message);
                    }
                }
                else if (node.Tag is User user)
                {
                    if (permissionManager.HasPermission(UserManagementPermissions.Update))
                    {
                        if (node.Parent.Tag is Group userGroup)
                        {
                            if (ShowDialog<AddUser>(userGroup, user))
                            {
                                logger.LogInfo(UserManagementPermissions.Update, "User '{0}' has been modified.", user);
                            }
                        }
                    }
                    else
                    {
                        var message = Lng.FormattedElem("User '{0}' has no permission to modify user.", args: permissionManager.CurrentUser);
                        logger.LogError(message);
                        throw new UnauthorizedAccessException(message);
                    }
                }
                Load();
            }
        }

        public void AddUser()
        {
            if (view.TvUsersAndGroups.SelectedNode.Tag is Group group)
            {
                ShowDialogWithReload<AddUser>(group);
            }
        }

        public void ChangeButtonStates(TreeNode treeNode)
        {
            var groupSelected = treeNode?.Tag is Group;
            var userSelected = treeNode?.Tag is User;
            var dbServerSelected = treeNode?.Tag is DatabaseServer;

            view.BtnNewGroup.Enabled = (permissionManager.HasPermission(GroupManagementPermissions.Create) && groupSelected);
            view.BtnNewUser.Enabled = (permissionManager.HasPermission(UserManagementPermissions.Create) && groupSelected);

            view.BtnModify.Enabled = permissionManager.HasPermission(GroupManagementPermissions.Update) && groupSelected ||
                (permissionManager.HasPermission(UserManagementPermissions.Update) && userSelected);

            view.BtnRemove.Enabled = permissionManager.HasPermission(GroupManagementPermissions.Delete) && groupSelected ||
                (permissionManager.HasPermission(UserManagementPermissions.Delete) && userSelected);
        }
    }
}
