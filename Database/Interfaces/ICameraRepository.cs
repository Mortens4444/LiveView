using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface ICameraRepository : IRepository<Camera>
    {
        void DeleteCamerasOfServer(long serverId);

        string SelectCameraName(long cameraId);
    }
}