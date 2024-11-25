using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class MapRepository<TModel> : BaseRepository<TModel>, IMapRepository<TModel>
    {
    }
}
