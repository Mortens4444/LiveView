using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class SequenceRepository : BaseRepository<Sequence, int>, ISequenceRepository
{
    public SequenceRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
    public long SelectCameraCount(long sequenceId)
    {
        return ExecuteScalar<long>("SelectSequenceCameraCount", new { SequenceId = sequenceId });
    }
}
