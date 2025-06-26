using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record GroupDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string OtherInformation { get; set; }

        public long? ParentGroupId { get; set; }

        public override string ToString()
        {
            return Name;
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>Name: {Name}</small><br>" +
                $"<small>OtherInformation: {OtherInformation}</small><br>" +
                $"<small>ParentGroupId: {ParentGroupId}</small>";
        }
    }
}
