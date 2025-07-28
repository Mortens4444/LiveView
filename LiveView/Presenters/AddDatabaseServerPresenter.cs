using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Models.Network;
using LiveView.Services.Network;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Threading.Tasks;

namespace LiveView.Presenters
{
    public class AddDatabaseServerPresenter : BasePresenter
    {
        private IAddDatabaseServerView view;
        private readonly IDatabaseServerRepository databaseServerRepository;
        private readonly ILogger<AddDatabaseServer> logger;
        private readonly PermissionManager<User> permissionManager;

        public AddDatabaseServerPresenter(AddDatabaseServerPresenterDependencies addDatabaseServerPresenterDependencies)
            : base(addDatabaseServerPresenterDependencies)
        {
            permissionManager = addDatabaseServerPresenterDependencies.PermissionManager;
            databaseServerRepository = addDatabaseServerPresenterDependencies.DatabaseServerRepository;
            logger = addDatabaseServerPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddDatabaseServerView;
        }

        public void LoadData(DatabaseServer server)
        {
            view.LoadData(server);
        }

        public async Task SearchForHostsAsync()
        {
            HostDiscoveryService.HostDiscovered += OnHostDiscovered;
            await Task.Run(HostDiscoveryService.Discovery);
            HostDiscoveryService.HostDiscovered -= OnHostDiscovered;
        }

        public void AddDatabaseOrModifyServer(DatabaseServer server = null)
        {
            var serverDto = view.GetDatabaseServerDto();
            var newServer = serverDto.ToModel();
            if (server == null)
            {
                if (permissionManager.HasPermission(DatabaseServerManagementPermissions.Create) == AccessResult.Allowed)
                {
                    databaseServerRepository.Insert(newServer);
                    logger.LogInfo(DatabaseServerManagementPermissions.Update, "Database server '{0}' has been created.", serverDto);
                }
                else
                {
                    var message = Lng.FormattedElem("User '{0}' has no permission to create database server.", args: permissionManager.CurrentUser);
                    logger.LogError(message);
                    throw new UnauthorizedAccessException(message);
                }
            }
            else
            {
                if (permissionManager.HasPermission(DatabaseServerManagementPermissions.Update) == AccessResult.Allowed)
                {
                    newServer.Id = server.Id;
                    databaseServerRepository.Update(newServer);
                    logger.LogInfo(DatabaseServerManagementPermissions.Update, "Database server '{0}' has been changed.", serverDto);
                }
                else
                {
                    var message = Lng.FormattedElem("User '{0}' has no permission to modify database server.", args: permissionManager.CurrentUser);
                    logger.LogError(message);
                    throw new UnauthorizedAccessException(message);
                }
            }
        }

        private void OnHostDiscovered(HostDiscoveryResult result)
        {
            view.AddToServerSelector(result);
        }
    }
}
