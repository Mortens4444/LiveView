using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Enums;

namespace LiveView.Presenters
{
    public class AddDatabaseServerPresenter : BasePresenter
    {
        private IAddDatabaseServerView view;
        private readonly IDatabaseServerRepository databaseServerRepository;
        private readonly ILogger<AddDatabaseServer> logger;

        public AddDatabaseServerPresenter(IGeneralOptionsRepository generalOptionsRepository, IDatabaseServerRepository databaseServerRepository, ILogger<AddDatabaseServer> logger)
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

        public void AddDatabaseOrModifyServer(DatabaseServer server = null)
        {
            var serverDto = view.GetDatabaseServerDto();
            var newServer = serverDto.ToModel();
            if (server == null)
            {
                databaseServerRepository.Insert(newServer);
            }
            else
            {
                newServer.Id = server.Id;
                databaseServerRepository.Update(newServer);
            }

            logger.LogInfo(ServerManagementPermissions.Create, "Database server '{0}' has been created.", serverDto);
        }
    }
}
