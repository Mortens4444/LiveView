using Database.Models;
using Mtf.Database.Interfaces;
using System.Collections.ObjectModel;

namespace Database.Interfaces
{
    public interface IOperationRepository : IRepository<Operation>
    {
        bool HasAnyRow();

        ReadOnlyCollection<Operation> SelectGroupOperations(long groupId);
    }
}
