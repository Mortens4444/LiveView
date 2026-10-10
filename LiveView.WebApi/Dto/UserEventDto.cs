using Mtf.Extensions.Interfaces;
using System.Net;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record UserEventDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

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
                $"<small>Note: {WebUtility.HtmlEncode(Note)}</small><br>" +
                $"<small>Name: {WebUtility.HtmlEncode(Name)}</small>";
        }
    }
}
