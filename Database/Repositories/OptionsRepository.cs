using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using System.Collections.Generic;

namespace Database.Repositories
{
    public sealed class OptionsRepository : BaseRepository<Options>, IOptionsRepository
    {
        //public Options SelectUserOptions()
        //{
        //    return Query<Options>("SelectUserOptions");
        //}
    }
}
