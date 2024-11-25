using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class MapObjectRepository<TModel> : BaseRepository<TModel>, IMapObjectRepository<TModel>
    {
        public string SelectCameraName(int cameraId)
        {
            return ExecuteScalar<string>("SelectCameraName", new { cid = cameraId });
        }
    }
}
