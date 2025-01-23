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

        public string GridCameraSetShowMethod(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraSetShowMethod", new { cid = cameraId });
        }

        public string GridCameraSetOSDState(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraSetOSDState", new { cid = cameraId });
        }

        public string GridCameraSetOSDAndShowDateState(int gridId)
        {
            return ExecuteScalar<string>("GridCameraSetOSDAndShowDateState", new { cid = gridId });
        }

        public string GridCameraSetTopLeftCoordinates(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraSetTopLeftCoordinates", new { cid = cameraId });
        }

        public string GridCameraSetHeightAndWidth(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraSetHeightAndWidth", new { cid = cameraId });
        }

        public string GridCameraReset(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraReset", new { cid = cameraId });
        }

        public string GridCameraSetFrameState(int gridId)
        {
            return ExecuteScalar<string>("GridCameraSetFrameState", new { cid = gridId });
        }

        public string GridCameraSetShowDateTimeState(int cameraId)
        {
            return ExecuteScalar<string>("GridCameraSetShowDateTimeState", new { cid = cameraId });
        }

        public void DeleteCamerasOfGrid(long gridId)
        {
            Execute("DeleteCamerasOfGrid", new { GridId = gridId });
        }
    }
}
