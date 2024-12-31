using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class ServerRepository : BaseRepository<Server>, IServerRepository
    {
    }
}
