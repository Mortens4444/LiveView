using Database.Enums;
using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record IOPortDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public int DeviceId { get; set; }

        public int PortNum { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public PortDirection Direction { get; set; }

        public int State { get; set; }

        public int MinTriggerTime { get; set; }

        public int MaxCount { get; set; }

        public override string ToString()
        {
            return FriendlyName ?? Name;
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>DeviceId: {DeviceId}</small><br>" +
                $"<small>Name: {Name}</small><br>" +
                $"<small>PortNum: {PortNum}</small><br>" +
                $"<small>FriendlyName: {FriendlyName}</small><br>" +
                $"<small>Direction: {Direction}</small>";
        }
    }
}
