using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class UserRepository : BaseRepository<User, int>, IUserRepository
{
    public UserRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
    public long GetUserCount()
    {
        return ExecuteScalar<long>("SelectNumberOfUsers");
    }

    public User Login(string encryptedUsername, string encryptedPassword)
    {
        return QuerySingleOrDefault("LoginUser", new
        {
            EncryptedUsername = encryptedUsername,
            EncryptedPassword = encryptedPassword
        });
    }

    public User SecondaryLogin(string encryptedUsername, string encryptedPassword)
    {
        return ExecuteScalar<User>("LoginUser", new
        {
            EncryptedUsername = encryptedUsername,
            EncryptedPassword = encryptedPassword
        });
    }
}
