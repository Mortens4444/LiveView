using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using System.Linq;

namespace Database.Repositories
{
    public sealed class DisplayRepository : BaseRepository<Display>, IDisplayRepository
    {
        public Display GetFullscreenDisplay()
        {
            return SelectAll().FirstOrDefault(d => d.Fullscreen);
        }
    }
}
