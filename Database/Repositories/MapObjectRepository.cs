using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class ActionObjectRepository : BaseRepository<ActionObject>, IActionObjectRepository
    {
        public string SelectCameraName(int cameraId)
        {
            return ExecuteScalar<string>("SelectCameraName", new { cid = cameraId });
        }
    }
}
