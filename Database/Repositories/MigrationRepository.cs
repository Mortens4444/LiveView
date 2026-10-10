using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class MigrationRepository : BaseRepository<Migration, int>, IMigrationRepository
{
    public MigrationRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
