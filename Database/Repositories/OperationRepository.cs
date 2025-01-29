using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using System.Collections.ObjectModel;

namespace Database.Repositories
{
    public sealed class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        public bool HasAnyRow()
        {
            return ExecuteScalar<int>("HasAnyRowOperation", null) != 0;
        }

        public ReadOnlyCollection<Operation> SelectGroupOperations(long groupId)
        {
            return Query("SelectGroupOperations", new { GroupId = groupId });
        }
    }
}
