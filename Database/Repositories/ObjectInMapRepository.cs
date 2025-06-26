using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using Mtf.Database.Interfaces;
using System;
using System.Collections.Generic;

namespace Database.Repositories
{
    public sealed class ObjectInMapRepository : BaseRepository<ObjectInMap>, IObjectInMapRepository
    {
        public void DeleteByKey(ObjectInMap key)
        {
            throw new NotImplementedException();
        }

        public ObjectInMap SelectByKey(ObjectInMap key)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ObjectInMap> IRepositoryWithCompositeKey<ObjectInMap, ObjectInMap>.SelectAll()
        {
            return SelectAll();
        }
    }
}
