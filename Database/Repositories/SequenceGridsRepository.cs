using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class SequenceGridsRepository : BaseRepository<SequenceGrid, int>, ISequenceGridsRepository
{
    public SequenceGridsRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
