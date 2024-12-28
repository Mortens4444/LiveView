using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class ObjectInMapRepository<TModel> : BaseRepository<TModel>, IObjectInMapRepository<TModel>
    {
    }
}
