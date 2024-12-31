using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IDisplayRepository : IRepository<Display>
    {
        Display GetFullscreenDisplay();
    }
}
