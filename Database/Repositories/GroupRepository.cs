using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public void DeleteGroupPermissions(long groupId)
        {
            Execute("DeleteGroupPermissions", new { GroupId = groupId });
        }
    }
}
