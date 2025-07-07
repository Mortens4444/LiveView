using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record GridDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public int PixelsFromRight { get; set; }

        public int PixelsFromBottom { get; set; }

        public string? Name { get; set; }

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
                $"<small>Rows x Columns: {Rows}x{Columns}</small><br>" +
                $"<small>Priority: {Priority}</small>";
        }
    }
}
