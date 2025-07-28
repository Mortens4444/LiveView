using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dependencies;
using Mtf.MessageBoxes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveView.Core.Services
{
    public class PermissionSetter
    {
        public static UserEvent ActualUserEvent { get; set; }
        
        public static int ActualUserEventId => ActualUserEvent?.Id ?? 1;

        private readonly ICameraRepository cameraRepository;
        private readonly ICameraPermissionRepository cameraPermissionRepository;
        private readonly IPermissionRepository permissionRepository;
        private readonly IGroupMembersRepository groupMembersRepository;
        private readonly IOperationRepository operationRepository;

        public PermissionSetter(PermissionSetterDependencies permissionSetterDependencies)
        {
            cameraRepository = permissionSetterDependencies.CameraRepository;
            cameraPermissionRepository = permissionSetterDependencies.CameraPermissionRepository;
            permissionRepository = permissionSetterDependencies.PermissionRepository;
            groupMembersRepository = permissionSetterDependencies.GroupMembersRepository;
            operationRepository = permissionSetterDependencies.OperationRepository;
        }

        public void SetGroups(Mtf.Permissions.Models.User<User> result)
        {
            result.Groups = new List<Mtf.Permissions.Models.Group>();
            var groupIds = groupMembersRepository.SelectWhere(new { UserId = result.Tag.Id }).Select(userGroup => userGroup.GroupId);
            foreach (var groupId in groupIds)
            {
                SetUserGroup(result, groupId, ActualUserEventId);
            }
        }

        private void SetUserGroup(Mtf.Permissions.Models.User<User> user, int groupId, int userEventId)
        {
            var group = new Mtf.Permissions.Models.Group { Id = groupId };
            var groupPermissions = permissionRepository.SelectWhere(new { GroupId = groupId, UserEventId = userEventId });
            var groupCameraPermissions = cameraPermissionRepository.SelectWhere(new { GroupId = groupId, UserEventId = userEventId });
            var operationIds = groupPermissions.Select(gp => gp.OperationId).ToList();
            var allowedCameraIds = groupCameraPermissions.Select(gcp => gcp.CameraId).ToList();
            var operations = operationRepository.SelectWhere(new { Ids = operationIds });
            var cameras = cameraRepository.SelectAll().Where(c => allowedCameraIds.Contains(c.Id));
            var permissionType = typeof(CameraManagementPermissions);
            var assembly = permissionType.Assembly;

            foreach (var camera in cameras)
            {
                var cameraGroupEnumType = assembly.GetType($"{permissionType.Namespace}.{PermissionManager.GetCameraGroupPermissionName(camera.PermissionCamera)}");
                var cameraPermissionValue = PermissionManager.GetCameraPermissionValue(camera.PermissionCamera);
                if ((cameraGroupEnumType != null) && (cameraPermissionValue != null))
                {
                    group.Permissions.Add(new Mtf.Permissions.Models.Permission
                    {
                        PermissionGroup = cameraGroupEnumType,
                        PermissionValue = Convert.ToInt64(cameraPermissionValue)
                    });
                }
            }

            foreach (var operation in operations)
            {
                var enumType = assembly.GetType($"{permissionType.Namespace}.{operation.PermissionGroup}");
                if (enumType != null && Enum.IsDefined(enumType, operation.PermissionValue))
                {
                    var enumValue = Enum.Parse(enumType, operation.PermissionValue);

                    group.Permissions.Add(new Mtf.Permissions.Models.Permission
                    {
                        PermissionGroup = enumType,
                        PermissionValue = Convert.ToInt64(enumValue)
                    });
                }
            }
            user.Groups.Add(group);
        }
    }
}
