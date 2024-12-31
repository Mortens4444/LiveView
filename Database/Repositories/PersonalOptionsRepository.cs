using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class PersonalOptionsRepository : BaseRepository<PersonalOption>, IPersonalOptionsRepository
    {
        public void DeletePersonalOptions()
        {
            Execute("DeletePersonalOptions");
        }
    }
}
