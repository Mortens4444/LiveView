using Database.Models;
using Mtf.Database.Interfaces;
using System.Collections.ObjectModel;

namespace Database.Interfaces
{
    public interface ICameraRepository : IRepository<Camera>
    {
        void DeleteCamerasOfVideoServer(long videoServerId);

        string SelectCameraName(long cameraId);

        ReadOnlyCollection<Camera> SelectGroupCameras(long groupId, long userEventId);

        ReadOnlyCollection<Camera> SelectMotionTriggeredCameras();

        Camera Select(GridCamera gridCamera);
    }
}