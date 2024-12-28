using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class UserEventRepository<TModel> : BaseRepository<TModel>, IUserEventRepository<TModel>
    {
    }
}
