using CameraForms.Enums;
using CameraForms.Interfaces;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dependencies;
using LiveView.Core.Dto;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Mtf.LanguageService;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Dto
{
    public class CameraLaunchContext
    {
        public CameraLaunchContext(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; set; }

        public int? AgentId { get; set; }

        public int UserId { get; set; }

        public int CameraId { get; set; }

        public string ServerIp { get; set; }

        public string VideoCaptureSource { get; set; }

        public int? DisplayId { get; set; }

        public Rectangle Rectangle { get; set; } = Rectangle.Empty;

        public CameraMode CameraMode { get; set; }

        public StartType StartType { get; set; }

        public DisplayDto GetDisplay()
        {
            if (Rectangle != Rectangle.Empty)
            {
                return null;
            }

            var displayProvider = ServiceProvider.GetRequiredService<IDisplayProvider>();
            var result = displayProvider.GetDisplay(DisplayId);
            if (!result.CanShowFullscreen)
            {
                throw new InvalidOperationException(Lng.FormattedElem("This display '{0}' is forbidden to show full screen camera windows.", args: result.Id));
            }
            return result;
        }

        public Tuple<PermissionManager<User>, PermissionSetter> CreatePermission(Form form)
        {
            var permissionManager = PermissionManagerBuilder.Build(ServiceProvider, form, UserId);
            var permissionSetter = new PermissionSetter(new PermissionSetterDependencies(
                ServiceProvider.GetRequiredService<ICameraRepository>(),
                ServiceProvider.GetRequiredService<ICameraPermissionRepository>(),
                ServiceProvider.GetRequiredService<IPermissionRepository>(),
                ServiceProvider.GetRequiredService<IOperationRepository>(),
                ServiceProvider.GetRequiredService<IGroupMembersRepository>()));
            permissionSetter.SetGroups(permissionManager.CurrentUser);
            return new Tuple<PermissionManager<User>, PermissionSetter>(permissionManager, permissionSetter);
        }
    }
}
