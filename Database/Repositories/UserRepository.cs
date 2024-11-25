using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class UserRepository <TModel> : BaseRepository<TModel>, IUserRepository<TModel>
    {
    }
}
