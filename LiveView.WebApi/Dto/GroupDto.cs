using Mtf.Extensions.Interfaces;
using System.Net;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record GroupDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OtherInformation { get; set; }

        public int? ParentGroupId { get; set; }

        public override string ToString()
        {
            return Name;
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>Name: {WebUtility.HtmlEncode(Name)}</small><br>" +
                $"<small>OtherInformation: {WebUtility.HtmlEncode(OtherInformation)}</small><br>" +
                $"<small>ParentGroupId: {ParentGroupId}</small>";
        }
    }
}
