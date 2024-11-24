using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class GridCameraListRepository : BaseRepository<GridCameraList>, IGridCameraListRepository
    {
        public string GridCameraListSetShowMethod(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraListSetShowMethod", new { cid = cameraId });
        }

        public string GridCameraListSetOSDState(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraListSetOSDState", new { cid = cameraId });
        }

        public string GridCameraListSetOSDAndShowDateState(int gridId)
        {
            return ExecuteScalar<string>("GridCameraListSetOSDAndShowDateState", new { cid = gridId });
        }

        public string GridCameraListSetTopLeftCoordinates(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraListSetTopLeftCoordinates", new { cid = cameraId });
        }

        public string GridCameraListSetHeightAndWidth(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraListSetHeightAndWidth", new { cid = cameraId });
        }

        public string GridCameraListReset(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraListReset", new { cid = cameraId });
        }

        public string GridCameraListSetFrameState(int gridId)
        {
            return ExecuteScalar<string>("GridCameraListSetFrameState", new { cid = gridId });
        }

        public string GridCameraListSetShowDateTimeState(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraListSetShowDateTimeState", new { cid = cameraId });
        }
    }
}
