using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IOperationRepository : IRepository<Operation>
    {
        bool HasAnyRow();
    }
}
