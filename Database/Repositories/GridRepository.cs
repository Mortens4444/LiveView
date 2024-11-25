using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class GridRepository<TModel> : BaseRepository<TModel>, IGridRepository<TModel>
    {
    }
}
