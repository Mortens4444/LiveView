using Database.Enums;
using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record ActionObjectDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public MapActionType ActionType { get; set; }

        public int ActionReferencedId { get; set; }

        public string Comment { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public byte[] Image { get; set; }


        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            var base64 = Image != null && Image.Length > 0
                ? Convert.ToBase64String(Image)
                : String.Empty;

            var imageTag = !String.IsNullOrEmpty(base64)
                ? $"<img src=\"data:image/png;base64,{base64}\" style=\"max-width: 300px; height: auto;\" />"
                : "<em>No image</em>";

            return $"<strong>{Id}</strong><br>" +
                $"<small>ActionType: {ActionType}</small><br>" +
                $"<small>ActionReferencedId: {ActionReferencedId}</small><br>" +
                $"<small>X, Y: {X}, {Y}</small><br>" +
                $"<small>Width x Height: {Width}x{Height}</small><br>" +
                $"<small>Comment: {Comment}</small><br>" +
                imageTag;
        }
    }
}
