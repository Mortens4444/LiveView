using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record RightDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public long? OperationId { get; set; }

        public long? UserEvent { get; set; }

        public long GroupId { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>Id: {Id}</strong><br>" +
                $"<small>OperationId: {OperationId}</small><br>" +
                $"<small>UserEvent: {UserEvent}</small><br>" +
                $"<small>GroupId: {GroupId}</small>";
        }
    }
}
