using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class AgentRepository : BaseRepository<Agent>, IAgentRepository
    {
        public Agent SelectByHost(string hostInfo)
        {
            return QuerySingleOrDefault("SelectAgentByHost", new
            {
                HostInfo = hostInfo
            });
        }

        public void DeleteAll()
        {
            Execute("DeleteAllAgent");
        }
    }
}
