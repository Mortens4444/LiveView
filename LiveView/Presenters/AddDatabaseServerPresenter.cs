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
        private readonly IAddDatabaseServerView view;
        private readonly IDatabaseServerRepository<DatabaseServer> databaseServerRepository;
        private readonly ILogger<AddDatabaseServer> logger;

        public AddDatabaseServerPresenter(IAddDatabaseServerView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IDatabaseServerRepository<DatabaseServer> databaseServerRepository, ILogger<AddDatabaseServer> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.databaseServerRepository = databaseServerRepository;
            this.logger = logger;
        }

        public void AddDatabaseServer()
        {
            throw new NotImplementedException();
        }
    }
}
