using System;

namespace LiveView.WebApi.Authorization
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RequiresPermissionGroupAttribute : Attribute
    {
        public RequiresPermissionGroupAttribute(Type permissionGroup)
        {
            PermissionGroup = permissionGroup;
        }

        public Type PermissionGroup { get; }
    }
}
