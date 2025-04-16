using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Agent SelectByHost(string hostInfo);

        void DeleteAll();
    }
}
