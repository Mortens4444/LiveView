using Mtf.Extensions.Interfaces;
using System.Net;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record MigrationDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{WebUtility.HtmlEncode(Name) ?? "N/A"}</strong><br>" +
                $"<small>Id: {Id}</small>";
        }
    }
}
