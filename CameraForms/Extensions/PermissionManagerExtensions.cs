using Database.Models;
using Mtf.Controls.Interfaces;
using Mtf.MessageBoxes;
using Mtf.Permissions.Services;
using System;

namespace CameraForms.Extensions
{
    public static class PermissionManagerExtensions
    {
        public static bool HasCameraAndUser(this PermissionManager<User> permissionManager, Camera camera)
        {
            if (permissionManager == null)
            {
                throw new ArgumentNullException(nameof(permissionManager));
            }

            if (camera == null)
            {
                throw new ArgumentNullException(nameof(camera));
            }

            if (permissionManager.CurrentUser == null)
            {
                DebugErrorBox.Show(camera.ToString(), "No user is logged in.");
                return false;
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
                if (permissionManager.HasCameraPermission(camera.PermissionCamera))
                {
                    return true;
                }
                else
                {
                    videoWindow.OverlayText = $"No permission: {camera}";
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
