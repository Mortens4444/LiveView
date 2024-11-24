using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class PersonalOptionsRepository : BaseRepository<PersonalOptions>, IPersonalOptionsRepository
    {
        public void DeletePersonalOptions()
        {
            Execute("DeletePersonalOptions");
        }
    }
}
