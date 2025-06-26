using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record IOPortsLogDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public int DeviceId { get; set; }

        public long UserId { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public int PortNum { get; set; }

        public int State { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>DeviceId: {DeviceId}</small><br>" +
                $"<small>UserId: {UserId}</small><br>" +
                $"<small>PortNum: {PortNum}</small><br>" +
                $"<small>Date: {Date}</small><br>" +
                $"<small>State: {State}</small><br>" +
                $"<small>Note: {Note}</small>";
        }
    }
}
