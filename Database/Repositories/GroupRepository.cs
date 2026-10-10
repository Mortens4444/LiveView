using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class GroupRepository : BaseRepository<Group, int>, IGroupRepository
    {
        public GroupRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
        public void DeleteGroupPermissions(int groupId)
        {
            Execute("DeleteAllGroupPermissions", new { GroupId = groupId });
        }

        public void DeleteGroupPermissions(int groupId, int userEventId)
        {
            Execute("DeleteGroupPermissions", new { GroupId = groupId, UserEventId = userEventId });
        }
    }
}
