using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class UsersInGroupsRepository <TModel> : BaseRepository<TModel>, IUsersInGroupsRepository<TModel>
    {
    }
}
