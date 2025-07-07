using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using Mtf.Database.Interfaces;
using System;
using System.Collections.Generic;

namespace Database.Repositories
{
    public sealed class MapActionObjectRepository : BaseRepository<MapActionObject>, IMapActionObjectRepository
    {
        public void DeleteByKey(MapActionObject key)
        {
            throw new NotImplementedException();
        }

        public MapActionObject SelectByKey(MapActionObject key)
        {
            throw new NotImplementedException();
        }

        IEnumerable<MapActionObject> IRepositoryWithCompositeKey<MapActionObject, MapActionObject>.SelectAll()
        {
            return SelectAll();
        }
    }
}
