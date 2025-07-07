using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record PermissionDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public int? OperationId { get; set; }

        public int? UserEventId { get; set; }

        public int GroupId { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>Id: {Id}</strong><br>" +
                $"<small>OperationId: {OperationId}</small><br>" +
                $"<small>UserEventId: {UserEventId}</small><br>" +
                $"<small>GroupId: {GroupId}</small>";
        }
    }
}
