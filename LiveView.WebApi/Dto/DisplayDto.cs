using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record DisplayDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int MaxWidth { get; set; }

        public int MaxHeight { get; set; }

        public string DeviceName { get; set; }

        public string MonitorName { get; set; }

        public string AdapterName { get; set; }

        public string SziltechId { get; set; }

        public bool IsPrimary { get; set; }

        public bool Removable { get; set; }

        public bool AttachedToDesktop { get; set; }

        public bool Fullscreen { get; set; }

        public bool CanShowSequence { get; set; } = true;

        public bool CanShowFullscreen { get; set; } = true;

        public int? AgentId { get; set; }

        public override string ToString()
        {
            return $"{SziltechId} (Id: {Id}, AgentId: {AgentId})";
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{DeviceName ?? "N/A"}</strong><br>" +
                $"<small>MonitorName: {MonitorName ?? "N/A"}</small><br>" +
                $"<small>AdapterName: {AdapterName}</small><br>" +
                $"<small>SziltechId: {SziltechId}</small>";
        }
    }
}
