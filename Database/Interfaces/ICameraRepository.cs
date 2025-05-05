using Database.Models;
using Mtf.Database.Interfaces;
using System.Collections.ObjectModel;

namespace Database.Interfaces
{
    public interface ICameraRepository : IRepository<Camera>
    {
        void DeleteCamerasOfServer(long serverId);

        string SelectCameraName(long cameraId);

        ReadOnlyCollection<Camera> SelectGroupCameras(long groupId, long userEventId);

        ReadOnlyCollection<Camera> SelectMotionTriggreredCameras();
    }
}