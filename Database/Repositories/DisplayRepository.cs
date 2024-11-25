using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class DisplayRepository<TModel> : BaseRepository<TModel>, IDisplayRepository<TModel>
    {
    }
}
