using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class UserEventRepository : BaseRepository<UserEvent>, IUserEventRepository
    {
        public UserEvent GetByName(string name)
        {
            return QuerySingleOrDefault("SelectUserEventByName", new { Name = name });
        }
    }
}
