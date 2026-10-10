using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using System.Collections.ObjectModel;

namespace Database.Repositories
{
    public sealed class GridCameraRepository : BaseRepository<GridCamera, int>, IGridCameraRepository
    {
    public GridCameraRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
        public ReadOnlyCollection<GridCamera> GetCombinedGridCameras(int gridId)
        {
            return Query("SelectCombinedGridCamera", new { GridId = gridId });
        }

        public void GridCameraSetShowMethod(int cameraId, int gridId, int initRow, int initCol, CameraMode cameraMode)
        {
            Execute("GridCameraSetShowMethod", new { CameraId = cameraId, GridId = gridId, InitRow = initRow, InitCol = initCol, CameraMode = cameraMode });
        }

        public void GridCameraSetOSDState(int cameraId, int gridId, int initRow, int initCol, bool osd)
        {
            Execute("GridCameraSetOSDState", new { CameraId = cameraId, GridId = gridId, InitRow = initRow, InitCol = initCol, Osd = osd });
        }

        public void GridCameraSetOSDAndShowDateState(int gridId, bool osd, bool showDateTime)
        {
            Execute("GridCameraSetOSDAndShowDateState", new { GridId = gridId, Osd = osd, ShowDateTime = showDateTime });
        }

        public void GridCameraSetTopLeftCoordinates(int cameraId, int gridId, int initRow, int initCol, int left, int top)
        {
            Execute("GridCameraSetTopLeftCoordinates", new { CameraId = cameraId, GridId = gridId, InitRow = initRow, InitCol = initCol, Left = left, Top = top });
        }

        public void GridCameraSetHeightAndWidth(int cameraId, int gridId, int initRow, int initCol, int width, int height)
        {
            Execute("GridCameraSetHeightAndWidth", new { CameraId = cameraId, GridId = gridId, InitRow = initRow, InitCol = initCol, Width = width, Height = height });
        }

        public void GridCameraReset(int gridId)
        {
            Execute("GridCameraReset", new { GridId = gridId });
        }

        public void GridCameraSetFrameState(int cameraId, int gridId, int initRow, int initCol, bool frame)
        {
            Execute("GridCameraSetFrameState", new { CameraId = cameraId, GridId = gridId, InitRow = initRow, InitCol = initCol, Frame = frame });
        }

        public void GridCameraSetShowDateTimeState(int cameraId, int gridId, int initRow, int initCol, bool showDateTime)
        {
            Execute("GridCameraSetShowDateTimeState", new { CameraId = cameraId, GridId = gridId, InitRow = initRow, InitCol = initCol, ShowDateTime = showDateTime });
        }

        public void DeleteCamerasOfGrid(int gridId)
        {
            Execute("DeleteCamerasOfGrid", new { GridId = gridId });
        }
    }
}
