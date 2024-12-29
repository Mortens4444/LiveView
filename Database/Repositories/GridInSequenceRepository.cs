using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class GridInSequenceRepository<TModel> : BaseRepository<TModel>, IGridInSequenceRepository<TModel>
    {
    }
}
