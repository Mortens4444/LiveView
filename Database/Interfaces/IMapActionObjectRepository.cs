using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IMapActionObjectRepository : IRepository<MapActionObject>, IRepositoryWithCompositeKey<MapActionObject, MapActionObject>
    {
    }
}
