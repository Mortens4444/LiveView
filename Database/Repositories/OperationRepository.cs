using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        public bool HasAnyRow()
        {
            return ExecuteScalar<int>("HasAnyRowOperation", null) != 0;
        }
    }
}
