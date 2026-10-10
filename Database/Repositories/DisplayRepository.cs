using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class DisplayRepository : BaseRepository<Display, int>, IDisplayRepository
{
    public DisplayRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
    public Display GetFullscreenDisplay()
    {
        return QuerySingleOrDefault("SelectFullscreenDisplay");
    }
}
