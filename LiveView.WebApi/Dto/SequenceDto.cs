using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record SequenceDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool Active { get; set; }

        public int? Priority { get; set; }

        public override string ToString()
        {
            return Name ?? String.Empty;
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Name}</strong><br>" +
                $"<small>Id: {Id}</small><br>" +
                $"<small>Active: {Active}</small><br>" +
                $"<small>Priority: {Priority}</small>";
        }
    }
}
