using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class BarcodeCharChangerRepository : BaseRepository<BarcodeCharChanger, int>, IBarcodeCharChangerRepository
{
    public BarcodeCharChangerRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
