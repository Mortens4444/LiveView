using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record IOPortsRuleDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public int DeviceId { get; set; }

        public int OperationId { get; set; }

        public int UserEventId { get; set; }

        public int PortNum { get; set; }

        public bool ZeroSignalled { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>DeviceId: {DeviceId}</small><br>" +
                $"<small>OperationId: {OperationId}</small><br>" +
                $"<small>UserEventId: {UserEventId}</small><br>" +
                $"<small>ZeroSignalled: {ZeroSignalled}</small><br>" +
                $"<small>PortNum: {PortNum}</small>";
        }
    }
}
