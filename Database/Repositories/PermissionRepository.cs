using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class PermissionRepository : BaseRepository<Permission, int>, IPermissionRepository
{
    public PermissionRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
