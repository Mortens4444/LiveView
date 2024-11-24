using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class SequenceRepository : BaseRepository<Sequence>, ISequenceRepository
    {
    }
}
