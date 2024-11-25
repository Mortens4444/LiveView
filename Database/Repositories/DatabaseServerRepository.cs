using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class DatabaseServerRepository<TModel> : BaseRepository<TModel>, IDatabaseServerRepository<TModel>
    {
    }
}
