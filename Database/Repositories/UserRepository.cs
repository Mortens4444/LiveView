using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        public long GetUserCount()
        {
            return ExecuteScalar<long>("SelectNumberOfUsers", null);
        }

        public User Login(string username, string password)
        {
            return QuerySingleOrDefault("LoginUser", new
            {
                Username = username,
                Password = password
            });
        }

        public User SecondaryLogin(string username, string password)
        {
            return ExecuteScalar<User>("SecondaryLoginUser", new
            {
                Username = username,
                Password = password
            });
        }
    }
}
