using Database.Enums;
using Database.Interfaces;

namespace Database.Models
{
    public class GridCamera : IHaveId<long>
    {
        public long Id { get; set; }

        public long GridId { get; set; }

        public long? CameraId { get; set; }

        public int InitRow { get; set; }

        public int InitCol { get; set; }

        public int? EndRow { get; set; }

        public int? EndCol { get; set; }

        public bool Osd { get; set; }

        public bool Frame { get; set; }

        public int? Left { get; set; }

        public int? Top { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public bool Ptz { get; set; }

        public bool MotionSaveImages { get; set; }

        public int MotionNumberOfPhotos { get; set; }

        public int MotionValue { get; set; }

        public bool CsrSaveImages { get; set; }

        public int CsrNumberOfPhotos { get; set; }

        public int CsrValue { get; set; }

        public bool ShowDateTime { get; set; } = false;

        public CameraMode CameraMode { get; set; }

        public MatrixRegion MatrixRegion => new MatrixRegion
        {
            FromRow = InitRow,
            FromColumn = InitCol,
            ToRow = EndRow ?? InitRow,
            ToColumn = EndCol ?? InitCol
        };
    }
}
