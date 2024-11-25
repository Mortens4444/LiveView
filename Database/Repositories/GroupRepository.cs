using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class GroupRepository <TModel> : BaseRepository<TModel>, IGroupRepository<TModel>
    {
    }
}
