using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record BarcodeScanReadingDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }
        
        public DateTime Date { get; set; }

        public string Value { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>Value: {Value ?? "N/A"}</small><br>" +
                $"<small>Date: {Date}</small>";
        }
    }
}
