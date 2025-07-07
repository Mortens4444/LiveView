using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record MapActionObjectDto
    {
        public int ActionObjectId { get; set; }

        public int MapId { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>MapId: {MapId}</strong><br>" +
                $"<small>ActionObjectId: {ActionObjectId}</small>";
        }
    }
}
