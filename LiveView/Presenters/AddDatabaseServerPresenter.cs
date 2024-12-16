using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class AddDatabaseServerPresenter : BasePresenter
    {
        private readonly IAddDatabaseServerView addDatabaseServerView;
        private readonly IDatabaseServerRepository<DatabaseServer> databaseServerRepository;
        private readonly ILogger<AddDatabaseServer> logger;

        public AddDatabaseServerPresenter(IAddDatabaseServerView addDatabaseServerView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IDatabaseServerRepository<DatabaseServer> databaseServerRepository, ILogger<AddDatabaseServer> logger)
            : base(addDatabaseServerView, generalOptionsRepository)
        {
            this.addDatabaseServerView = addDatabaseServerView;
            this.databaseServerRepository = databaseServerRepository;
            this.logger = logger;
        }

        public void AddDatabaseServer()
        {
            throw new NotImplementedException();
        }
    }
}
