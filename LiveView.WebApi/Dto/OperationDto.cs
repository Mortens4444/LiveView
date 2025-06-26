using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record OperationDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public string PermissionGroup { get; set; }

        public string PermissionValue { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>Id: {Id}</strong><br>" +
                $"<small>PermissionGroup: {PermissionGroup}</small><br>" +
                $"<small>PermissionValue: {PermissionValue}</small>";
        }
    }
}
