using Database.Enums;
using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record CameraFunctionDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public long CameraId { get; set; }

        public CameraFunctionType FunctionId { get; set; }

        public string FunctionCallback { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>CameraId: {CameraId}</small><br>" +
                $"<small>FunctionId: {FunctionId}</small><br>" +
                $"<small>FunctionCallback: {FunctionCallback}</small>";
        }
    }
}
