using Database.Models;
using Mtf.Controls.Interfaces;
using Mtf.MessageBoxes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace CameraForms.Extensions
{
    public static class PermissionManagerExtensions
    {
        public static bool HasCamera(this PermissionManager<User> permissionManager, Camera camera)
        {
            if (permissionManager == null)
            {
                throw new ArgumentNullException(nameof(permissionManager));
            }

            if (camera == null)
            {
                throw new ArgumentNullException(nameof(camera));
            }

            return true;
        }

        public static bool HasCameraPermission(this PermissionManager<User> permissionManager, Camera camera, IVideoWindow videoWindow)
        {
            if (permissionManager == null)
            {
                throw new ArgumentNullException(nameof(permissionManager));
            }
            if (camera == null)
            {
                throw new ArgumentNullException(nameof(camera));
            }
            if (videoWindow == null)
            {
                throw new ArgumentNullException(nameof(videoWindow));
            }

            try
            {
                var accessResult = permissionManager.HasCameraPermission(camera.PermissionCamera);
                if (accessResult == AccessResult.Allowed)
                {
                    return true;
                }
                else
                {
                    videoWindow.OverlayText = $"No permission ({accessResult}): {camera} ({camera.PermissionCamera}) - {permissionManager.CurrentUser?.Username} ({permissionManager.CurrentUser?.Id ?? 0})";
                    DebugErrorBox.Show(camera.ToString(), "No permission to view this camera.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
                return false;
            }
        }
    }
}
