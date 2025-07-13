using Database.Interfaces;

namespace LiveView.Core.Dependencies
{
    public class PermissionSetterDependencies
    {
        public PermissionSetterDependencies(
            ICameraRepository cameraRepository,
            ICameraPermissionRepository cameraRightRepository,
            IPermissionRepository rightRepository,
            IOperationRepository operationRepository,
            IGroupMembersRepository groupMembersRepository)
        {
            CameraRepository = cameraRepository;
            CameraPermissionRepository = cameraRightRepository;
            PermissionRepository = rightRepository;
            OperationRepository = operationRepository;
            GroupMembersRepository = groupMembersRepository;
        }

        public ICameraRepository CameraRepository { get; private set; }

        public ICameraPermissionRepository CameraPermissionRepository { get; private set; }
        
        public IPermissionRepository PermissionRepository { get; private set; }

        public IOperationRepository OperationRepository { get; private set; }

        public IGroupMembersRepository GroupMembersRepository { get; private set; }
    }
}
