using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record UserGroupDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }

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
