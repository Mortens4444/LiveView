using Database.Interfaces;

namespace LiveView.Core.Dependencies
{
    public class PermissionSetterDependencies
    {
        public PermissionSetterDependencies(
            ICameraRepository cameraRepository,
            ICameraRightRepository cameraRightRepository,
            IRightRepository rightRepository,
            IOperationRepository operationRepository,
            IUsersInGroupsRepository userGroupRepository)
        {
            CameraRepository = cameraRepository;
            CameraRightRepository = cameraRightRepository;
            RightRepository = rightRepository;
            OperationRepository = operationRepository;
            UserGroupRepository = userGroupRepository;
        }

        public ICameraRepository CameraRepository { get; private set; }

        public ICameraRightRepository CameraRightRepository { get; private set; }
        
        public IRightRepository RightRepository { get; private set; }

        public IOperationRepository OperationRepository { get; private set; }

        public IUsersInGroupsRepository UserGroupRepository { get; private set; }
    }
}
