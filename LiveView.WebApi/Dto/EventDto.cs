using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record EventDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public long LanguageElementId { get; set; }

        public string Note { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>LanguageElementId: {LanguageElementId}</small><br>" +
                $"<small>Note: {Note}</small>";
        }
    }
}
