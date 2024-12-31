using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public Group GetByName(string name)
        {
            return QuerySingleOrDefault("SelectGroupByName", new { Name = name });
        }
    }
}
