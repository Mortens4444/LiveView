using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class DisplayRepository : BaseRepository<Display>, IDisplayRepository
    {
        public Display GetFullscreenDisplay()
        {
            return QuerySingleOrDefault("SelectFullscreenDisplay");
        }
    }
}
