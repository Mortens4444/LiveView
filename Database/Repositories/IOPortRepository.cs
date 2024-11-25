using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class IOPortRepository <TModel> : BaseRepository<TModel>, IIOPortRepository<TModel>
    {
    }
}
