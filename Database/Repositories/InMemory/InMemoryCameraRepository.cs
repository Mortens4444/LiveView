using Database.Interfaces;
using Database.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Database.Repositories.InMemory;

public sealed class InMemoryCameraRepository : InMemoryRepository<Camera, int>, ICameraRepository
{
    public void DeleteCamerasOfVideoServer(long videoServerId)
    {
        DeleteWhere(new { VideoServerId = videoServerId });
    }

    public string SelectCameraName(long cameraId)
    {
        lock (SyncRoot)
        {
            return Items.FirstOrDefault(camera => camera.Id == cameraId)?.CameraName;
        }
    }

    public ReadOnlyCollection<Camera> SelectGroupCameras(long groupId, long userEventId)
    {
        lock (SyncRoot)
        {
            var cameraIds = InMemoryStore<CameraPermission>.Items
                .Where(permission => permission.GroupId == groupId && permission.UserEventId == userEventId && permission.CameraId.HasValue)
                .Select(permission => permission.CameraId.Value)
                .ToList();
            return Copy(Items.Where(camera => cameraIds.Contains(camera.Id)));
        }
    }

    public ReadOnlyCollection<Camera> SelectMotionTriggeredCameras()
    {
        // The SQL script has no filter either, the callers decide which cameras trigger on motion.
        return SelectAll();
    }

    public Camera Select(GridCamera gridCamera)
    {
        if (gridCamera == null)
        {
            return null;
        }

        return gridCamera.CameraId.HasValue ? Select(gridCamera.CameraId.Value) : null;
    }

    /// <summary>Same as the join with VideoServers/Credentials in the SQL select scripts.</summary>
    protected override Camera Hydrate(Camera camera)
    {
        var server = InMemoryStore<VideoServer>.Items.FirstOrDefault(videoServer => videoServer.Id == camera.VideoServerId);
        if (server != null)
        {
            camera.ServerDisplayName = server.Hostname;
            camera.ServerEncryptedUsername = server.EncryptedUsername;
            camera.ServerEncryptedPassword = server.EncryptedPassword;
        }

        return camera;
    }

    /// <summary>The SQL insert script gives every camera the first free permission number.</summary>
    protected override void OnInserting(Camera camera)
    {
        var used = Items.Select(existing => existing.PermissionCamera).ToHashSet();
        camera.PermissionCamera = used.Count == 0 ? 1 : used.Select(number => number + 1).Where(number => !used.Contains(number)).Min();
    }

    protected override void OnDeleted(Camera camera)
    {
        foreach (var gridCamera in InMemoryStore<GridCamera>.Items.Where(gridCamera => gridCamera.CameraId == camera.Id))
        {
            gridCamera.CameraId = null;
        }

        new InMemoryCameraPermissionRepository().DeleteWhere(new { CameraId = camera.Id });
        new InMemoryCameraFunctionRepository().DeleteWhere(new { CameraId = camera.Id });
    }
}
