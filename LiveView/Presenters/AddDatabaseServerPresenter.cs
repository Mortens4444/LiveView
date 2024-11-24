using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class AddDatabaseServerPresenter
    {
        private readonly IAddDatabaseServerView addDatabaseServerView;
        private readonly IDatabaseServerRepository databaseServerRepository;

        public AddDatabaseServerPresenter(IAddDatabaseServerView addDatabaseServerView, IDatabaseServerRepository databaseServerRepository)
        {
            this.addDatabaseServerView = addDatabaseServerView;
            this.databaseServerRepository = databaseServerRepository;
        }
    }
}
