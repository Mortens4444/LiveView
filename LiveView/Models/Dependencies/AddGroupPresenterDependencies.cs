using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class AddGroupPresenterDependencies : BasePresenterDependencies
    {
        public AddGroupPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IGroupRepository groupRepository,
            IUserEventRepository userEventRepository,
            IOperationRepository operationRepository,
            ICameraRepository cameraRepository,
            IRightRepository rightRepository,
            ICameraRightRepository cameraRightRepository,
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

        public IGroupRepository GroupRepository { get; private set; }

        public IUserEventRepository UserEventRepository { get; private set; }

        public IOperationRepository OperationRepository { get; private set; }

        public IRightRepository RightRepository { get; private set; }

        public ILogger<AddGroup> Logger { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public ICameraRightRepository CameraRightRepository { get; private set; }
    }
}
