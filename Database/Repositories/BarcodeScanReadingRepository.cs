using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class BarcodeScanReadingRepository : BaseRepository<BarcodeScanReading, int>, IBarcodeScanReadingRepository
{
    public BarcodeScanReadingRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
