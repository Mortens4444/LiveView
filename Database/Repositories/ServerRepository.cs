using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class ServerRepository<TModel> : BaseRepository<TModel>, IServerRepository<TModel>
    {
    }
}
