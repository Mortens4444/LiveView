using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class InputOutputPortRuleRepository : BaseRepository<InputOutputPortRule, int>, IInputOutputPortRuleRepository
{
    public InputOutputPortRuleRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
