using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

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

        public void AddDatabaseOrModifyServer(DatabaseServer server = null)
        {
            var serverDto = view.GetDatabaseServerDto();
            var newServer = serverDto.ToModel();
            if (server == null)
            {
                if (permissionManager.CurrentUser.HasPermission(DatabaseServerManagementPermissions.Create))
                {
                    databaseServerRepository.Insert(newServer);
                    logger.LogInfo(DatabaseServerManagementPermissions.Update, "Database server '{0}' has been created.", serverDto);
                }
                else
                {
                    logger.LogError("User '{0}' has no permission to create database server.", permissionManager.CurrentUser);
                    throw new UnauthorizedAccessException();
                }
            }
            else
            {
                if (permissionManager.CurrentUser.HasPermission(DatabaseServerManagementPermissions.Update))
                {
                    newServer.Id = server.Id;
                    databaseServerRepository.Update(newServer);
                    logger.LogInfo(DatabaseServerManagementPermissions.Update, "Database server '{0}' has been changed.", serverDto);
                }
                else
                {
                    logger.LogError("User '{0}' has no permission to modify database server.", permissionManager.CurrentUser);
                    throw new UnauthorizedAccessException();
                }
            }
        }
    }
}
