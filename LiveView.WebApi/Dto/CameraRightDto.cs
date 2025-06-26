using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record CameraRightDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public long? CameraId { get; set; }

        public long? UserEvent { get; set; }

        public long GroupId { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>CameraId: {CameraId}</small><br>" +
                $"<small>UserEvent: {UserEvent}</small><br>" +
                $"<small>GroupId: {GroupId}</small>";
        }
    }
}
