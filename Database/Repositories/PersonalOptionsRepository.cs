using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class PersonalOptionsRepository<TModel> : BaseRepository<TModel>, IPersonalOptionsRepository<TModel>
    {
        public void DeletePersonalOptions()
        {
            Execute("DeletePersonalOptions");
        }
    }
}
