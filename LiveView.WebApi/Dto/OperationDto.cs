using Mtf.Extensions.Interfaces;
using System.Net;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record OperationDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public string PermissionGroup { get; set; }

        public string PermissionValue { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>Id: {Id}</strong><br>" +
                $"<small>PermissionGroup: {WebUtility.HtmlEncode(PermissionGroup)}</small><br>" +
                $"<small>PermissionValue: {WebUtility.HtmlEncode(PermissionValue)}</small>";
        }
    }
}
