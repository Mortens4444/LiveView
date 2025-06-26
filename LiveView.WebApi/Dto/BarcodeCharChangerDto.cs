using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record BarcodeCharChangerDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public string Chars { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>Chars: {Chars ?? "N/A"}</small>";
        }
    }
}
