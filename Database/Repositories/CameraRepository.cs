using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class CameraRepository : BaseRepository<Camera>, ICameraRepository
    {
        public void DeleteCamerasOfServer(long serverId)
        {
            Execute("DeleteCamerasOfServer", new { ServerId = serverId });
        }

        public string SelectCameraName(long cameraId)
        {
            return ExecuteScalar<string>("SelectCameraName", new { cid = cameraId });
        }
    }
}
