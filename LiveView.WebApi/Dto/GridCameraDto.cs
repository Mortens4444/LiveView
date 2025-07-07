using Database.Enums;
using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record GridCameraDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public int GridId { get; set; }

        public int? CameraId { get; set; }

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

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>GridId: {GridId}</small><br>" +
                $"<small>CameraId: {CameraId}</small><br>" +
                $"<small>InitRow, InitCol: {InitRow}x{InitCol}</small><br>" +
                $"<small>EndRow, EndCol: {EndRow}x{EndCol}</small>";
        }
    }
}
