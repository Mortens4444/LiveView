using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class AddDatabaseServerPresenter : BasePresenter
    {
        private readonly IAddDatabaseServerView addDatabaseServerView;
        private readonly IDatabaseServerRepository<DatabaseServer> databaseServerRepository;
        private readonly ILogger<AddDatabaseServer> logger;

        public AddDatabaseServerPresenter(IAddDatabaseServerView addDatabaseServerView, IDatabaseServerRepository<DatabaseServer> databaseServerRepository, ILogger<AddDatabaseServer> logger)
            : base(addDatabaseServerView)
        {
            this.addDatabaseServerView = addDatabaseServerView;
            this.databaseServerRepository = databaseServerRepository;
            this.logger = logger;
        }
    }
}
