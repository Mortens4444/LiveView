using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record UserEventDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public string Note { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>Id: {Id}</strong><br>" +
                $"<small>Note: {Note}</small><br>" +
                $"<small>Name: {Name}</small>";
        }
    }
}
