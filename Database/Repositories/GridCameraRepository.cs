using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using System.Collections.ObjectModel;

namespace Database.Repositories
{
    public sealed class GridCameraRepository : BaseRepository<GridCamera>, IGridCameraRepository
    {
        public ReadOnlyCollection<GridCamera> GetCombinedGridCameras(long gridId)
        {
            return Query("SelectCombinedGridCamera", new { GridId = gridId });
        }

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

        public void DeleteCamerasOfGrid(long gridId)
        {
            Execute("DeleteCamerasOfGrid", new { GridId = gridId });
        }
    }
}
