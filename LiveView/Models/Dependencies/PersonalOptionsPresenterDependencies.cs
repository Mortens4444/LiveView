using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class PersonalOptionsPresenterDependencies : BasePresenterDependencies
    {
        public PersonalOptionsPresenterDependencies(
            PermissionManager permissionManager,
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository,
            ILogger<PersonalOptionsForm> logger)
            : base(generalOptionsRepository)
        {
            PermissionManager = permissionManager;
            PersonalOptionsRepository = personalOptionsRepository;
            Logger = logger;
        }

        public PermissionManager PermissionManager { get; private set; }

        public IPersonalOptionsRepository<PersonalOptions> PersonalOptionsRepository { get; private set; }

        public ILogger<PersonalOptionsForm> Logger { get; private set; }
    }
}
