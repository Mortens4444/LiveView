using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class CameraRepository<TModel> : BaseRepository<TModel>, ICameraRepository<TModel>
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
