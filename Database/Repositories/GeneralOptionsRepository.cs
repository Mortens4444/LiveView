using Database.Interfaces;
using Mtf.Database;
using System.Collections.Generic;

namespace Database.Repositories
{
    public sealed class GeneralOptionsRepository<TModel> : BaseRepository<TModel>, IGeneralOptionsRepository<TModel>
    {
        //public Options SelectUserOptions()
        //{
        //    return Query<Options>("SelectUserOptions");
        //}
    }
}
