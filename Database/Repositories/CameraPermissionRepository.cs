using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class CameraPermissionRepository : BaseRepository<CameraPermission, int>, ICameraPermissionRepository
{
    public CameraPermissionRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
