using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class OperationRepository<TModel> : BaseRepository<TModel>, IOperationRepository<TModel>
    {
    }
}
