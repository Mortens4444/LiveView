using Database.Interfaces;
using Mtf.Database;
using System.Collections.Generic;

namespace Database.Repositories
{
    public sealed class OptionsRepository<TModel> : BaseRepository<TModel>, IOptionsRepository<TModel>
    {
        //public Options SelectUserOptions()
        //{
        //    return Query<Options>("SelectUserOptions");
        //}
    }
}
