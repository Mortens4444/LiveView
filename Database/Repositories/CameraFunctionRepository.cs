using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class CameraFunctionRepository : BaseRepository<CameraFunction, int>, ICameraFunctionRepository
{
    public CameraFunctionRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
