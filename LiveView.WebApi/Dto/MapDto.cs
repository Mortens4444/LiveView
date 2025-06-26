using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record MapDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int OriginalWidth { get; set; }

        public int OriginalHeight { get; set; }

        public byte[] MapImage { get; set; }

        public override string ToString()
        {
            return Name;
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            var base64 = MapImage != null && MapImage.Length > 0
                ? Convert.ToBase64String(MapImage)
                : String.Empty;

            var imageTag = !String.IsNullOrEmpty(base64)
                ? $"<img src=\"data:image/png;base64,{base64}\" style=\"max-width: 300px; height: auto;\" />"
                : "<em>No image</em>";

            return $"<strong>{Id}</strong><br>" +
                $"<small>Name: {Name}</small><br>" +
                $"<small>Comment: {Comment}</small><br>" +
                $"<small>OriginalWidth, OriginalHeight: {OriginalWidth}x{OriginalHeight}</small><br>" +
                imageTag;
        }
    }
}
