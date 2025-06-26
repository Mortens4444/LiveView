using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record IOPortsRuleDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public int DeviceId { get; set; }

        public long OperationId { get; set; }

        public long EventId { get; set; }

        public int PortNum { get; set; }

        public bool ZeroSignalled { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>DeviceId: {DeviceId}</small><br>" +
                $"<small>OperationId: {OperationId}</small><br>" +
                $"<small>EventId: {EventId}</small><br>" +
                $"<small>ZeroSignalled: {ZeroSignalled}</small><br>" +
                $"<small>PortNum: {PortNum}</small>";
        }
    }
}
