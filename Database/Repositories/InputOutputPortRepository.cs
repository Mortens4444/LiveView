using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class InputOutputPortRepository : BaseRepository<InputOutputPort, int>, IInputOutputPortRepository
    {
        public InputOutputPortRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
    }
}
