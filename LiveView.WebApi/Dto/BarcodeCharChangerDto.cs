using Mtf.Extensions.Interfaces;
using System.Net;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record BarcodeCharChangerDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public string Chars { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>Chars: {WebUtility.HtmlEncode(Chars) ?? "N/A"}</small>";
        }
    }
}
