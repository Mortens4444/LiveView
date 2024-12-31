using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class PersonalOptionsPresenterDependencies : BasePresenterDependencies
    {
        public PersonalOptionsPresenterDependencies(
            PermissionManager permissionManager,
            IGeneralOptionsRepository generalOptionsRepository,
            IPersonalOptionsRepository personalOptionsRepository,
            ILogger<PersonalOptionsForm> logger)
            : base(generalOptionsRepository)
        {
            PermissionManager = permissionManager;
            PersonalOptionsRepository = personalOptionsRepository;
            Logger = logger;
        }

        public PermissionManager PermissionManager { get; private set; }

        public IPersonalOptionsRepository PersonalOptionsRepository { get; private set; }

        public ILogger<PersonalOptionsForm> Logger { get; private set; }
    }
}
