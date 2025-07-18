using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        public long GetUserCount()
        {
            return ExecuteScalar<long>("SelectNumberOfUsers");
        }

        public User Login(string username, string encryptedPassword)
        {
            return QuerySingleOrDefault("LoginUser", new
            {
                Username = username,
                EncryptedPassword = encryptedPassword
            });
        }

        public User SecondaryLogin(string username, string encryptedPassword)
        {
            return ExecuteScalar<User>("LoginUser", new
            {
                Username = username,
                EncryptedPassword = encryptedPassword
            });
        }
    }
}
