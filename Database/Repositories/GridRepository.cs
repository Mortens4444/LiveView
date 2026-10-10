using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class GridRepository : BaseRepository<Grid, int>, IGridRepository
{
    public GridRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
