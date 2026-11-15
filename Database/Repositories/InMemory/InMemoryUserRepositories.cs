using Database.Interfaces;
using Database.Models;
using System;
using System.Linq;

namespace Database.Repositories.InMemory;

public sealed class InMemoryUserRepository : InMemoryRepository<User, int>, IUserRepository
{
    public User Login(string encryptedUsername, string encryptedPassword)
    {
        lock (SyncRoot)
        {
            var user = Items.FirstOrDefault(existing =>
                String.Equals(existing.EncryptedUsername, encryptedUsername, StringComparison.OrdinalIgnoreCase)
                && String.Equals(existing.EncryptedPassword, encryptedPassword, StringComparison.OrdinalIgnoreCase));
            return user == null ? null : Copy(new[] { user }).First();
        }
    }

    public User SecondaryLogin(string encryptedUsername, string encryptedPassword)
    {
        return Login(encryptedUsername, encryptedPassword);
    }

    protected override void OnDeleted(User user)
    {
        new InMemoryGroupMembersRepository().DeleteWhere(new { UserId = user.Id });
        new InMemoryPersonalOptionsRepository().DeleteWhere(new { UserId = (long)user.Id });
    }
}

public sealed class InMemoryGroupRepository : InMemoryRepository<Group, int>, IGroupRepository
{
    public void DeleteGroupPermissions(int groupId)
    {
        new InMemoryPermissionRepository().DeleteWhere(new { GroupId = groupId });
        new InMemoryCameraPermissionRepository().DeleteWhere(new { GroupId = groupId });
    }

    public void DeleteGroupPermissions(int groupId, int userEventId)
    {
        new InMemoryPermissionRepository().DeleteWhere(new { GroupId = groupId, UserEventId = userEventId });
        new InMemoryCameraPermissionRepository().DeleteWhere(new { GroupId = groupId, UserEventId = userEventId });
    }

    /// <summary>
    /// Same as DeleteGroup.sql: members of the group (and of its subgroups) lose their secondary logon,
    /// subgroups are deleted with the group, permissions and memberships follow.
    /// </summary>
    protected override void OnDeleted(Group group)
    {
        var affectedGroupIds = Items.Where(child => child.ParentGroupId == group.Id).Select(child => child.Id).Append(group.Id).ToList();
        var userIds = InMemoryStore<GroupMember>.Items.Where(member => affectedGroupIds.Contains(member.GroupId)).Select(member => member.UserId).ToList();
        foreach (var user in InMemoryStore<User>.Items.Where(user => userIds.Contains(user.Id)))
        {
            user.NeededSecondaryLogonPriority = 100;
        }

        DeleteWhere(new { ParentGroupId = group.Id });
        new InMemoryGroupMembersRepository().DeleteWhere(new { GroupId = group.Id });
        DeleteGroupPermissions(group.Id);
    }
}
