using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class AgentRepository : BaseRepository<Agent, int>, IAgentRepository
{
    public AgentRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
