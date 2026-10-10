using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class UserEventRepository : BaseRepository<UserEvent, int>, IUserEventRepository
{
    public UserEventRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }

    public UserEvent GetByName(string name)
    {
        return QuerySingleOrDefault("SelectUserEventByName", new { Name = name });
    }
}
