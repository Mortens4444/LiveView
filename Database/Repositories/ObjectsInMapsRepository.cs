using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class ObjectsInMapsRepository<TModel> : BaseRepository<TModel>, IObjectsInMapsRepositoryRepository<TModel>
    {
    }
}
