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
        private IAddDatabaseServerView view;
        private readonly IDatabaseServerRepository<DatabaseServer> databaseServerRepository;
        private readonly ILogger<AddDatabaseServer> logger;

        public AddDatabaseServerPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IDatabaseServerRepository<DatabaseServer> databaseServerRepository, ILogger<AddDatabaseServer> logger)
            : base(generalOptionsRepository)
        {
            this.databaseServerRepository = databaseServerRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddDatabaseServerView;
        }

        public void AddDatabaseServer()
        {
            throw new NotImplementedException();
        }
    }
}
