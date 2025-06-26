using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record ObjectInMapDto
    {
        public int MapObjectId { get; set; }

        public int MapId { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>MapId: {MapId}</strong><br>" +
                $"<small>MapObjectId: {MapObjectId}</small>";
        }
    }
}
