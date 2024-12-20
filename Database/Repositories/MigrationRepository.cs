using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class MigrationRepository<TModel> : BaseRepository<TModel>, IMapRepository<TModel>
    {
    }
}
