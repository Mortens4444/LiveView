using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class CameraRepository<TModel> : BaseRepository<TModel>, ICameraRepository<TModel>
    {
        public string SelectCameraName(int cameraId)
        {
            return ExecuteScalar<string>("SelectCameraName", new { cid = cameraId });
        }
    }
}
