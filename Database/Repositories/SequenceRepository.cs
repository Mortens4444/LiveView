using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class SequenceRepository<TModel> : BaseRepository<TModel>, ISequenceRepository<TModel>
    {
    }
}
