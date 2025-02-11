using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class AddDatabaseServerPresenterDependencies : BasePresenterDependencies
    {
        public AddDatabaseServerPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            PermissionManager<User> permissionManager,
            IDatabaseServerRepository databaseServerRepository,
            ILogger<AddDatabaseServer> logger)
            : base(generalOptionsRepository)
        {
            DatabaseServerRepository = databaseServerRepository;
            PermissionManager = permissionManager;
            Logger = logger;
        }

        public IDatabaseServerRepository DatabaseServerRepository { get; private set; }

        public PermissionManager<User> PermissionManager { get; private set; }
        
        public ILogger<AddDatabaseServer> Logger { get; private set; }
    }
}
