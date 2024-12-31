using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class MapObjectRepository : BaseRepository<MapObject>, IMapObjectRepository
    {
        public string SelectCameraName(int cameraId)
        {
            return ExecuteScalar<string>("SelectCameraName", new { cid = cameraId });
        }
    }
}
