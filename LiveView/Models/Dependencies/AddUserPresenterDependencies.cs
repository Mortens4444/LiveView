using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class AddUserPresenterDependencies : BasePresenterDependencies
    {
        public AddUserPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IUserRepository userRepository,
            IGroupMembersRepository groupMembersRepository,
            ILogger<AddUser> logger)
            : base(generalOptionsRepository)
        {
            UserRepository = userRepository;
            GroupMembersRepository = groupMembersRepository;
            Logger = logger;
        }

        public IUserRepository UserRepository { get; private set; }

        public ILogger<AddUser> Logger { get; private set; }

        public IGroupMembersRepository GroupMembersRepository { get; private set; }
    }
}
