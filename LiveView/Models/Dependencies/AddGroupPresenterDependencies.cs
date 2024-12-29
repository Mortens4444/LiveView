using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class AddGroupPresenterDependencies : BasePresenterDependencies
    {
        public AddGroupPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IGroupRepository<Group> groupRepository,
            IUserEventRepository<UserEvent> userEventRepository,
            IOperationRepository<Operation> operationRepository,
            ICameraRepository<Camera> cameraRepository,
            IRightRepository<Right> rightRepository,
            ICameraRightRepository<CameraRight> cameraRightRepository,
            ILogger<AddGroup> logger)
            : base(generalOptionsRepository)
        {
            GroupRepository = groupRepository;
            UserEventRepository = userEventRepository;
            OperationRepository = operationRepository;
            CameraRepository = cameraRepository;
            RightRepository = rightRepository;
            CameraRightRepository = cameraRightRepository;
            Logger = logger;
        }

        public IGroupRepository<Group> GroupRepository { get; private set; }

        public IUserEventRepository<UserEvent> UserEventRepository { get; private set; }

        public IOperationRepository<Operation> OperationRepository { get; private set; }

        public IRightRepository<Right> RightRepository { get; private set; }

        public ILogger<AddGroup> Logger { get; private set; }

        public ICameraRepository<Camera> CameraRepository { get; private set; }

        public ICameraRightRepository<CameraRight> CameraRightRepository { get; private set; }
    }
}
