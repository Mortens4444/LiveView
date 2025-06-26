using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record MigrationDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Name ?? "N/A"}</strong><br>" +
                $"<small>Id: {Id}</small>";
        }
    }
}
