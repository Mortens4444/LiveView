using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class GridsInSequencesRepository<TModel> : BaseRepository<TModel>, IGridsInSequencesRepository<TModel>
    {
    }
}
