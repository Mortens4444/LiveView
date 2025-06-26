using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record UserGroupDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long GroupId { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>Id: {Id}</strong><br>" +
                $"<small>UserId: {UserId}</small><br>" +
                $"<small>GroupId: {GroupId}</small>";
        }
    }
}
