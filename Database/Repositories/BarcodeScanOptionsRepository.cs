using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class BarcodeScanOptionsRepository : BaseRepository<BarcodeScanOptions, int>, IBarcodeScanOptionsRepository
{
    public BarcodeScanOptionsRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
