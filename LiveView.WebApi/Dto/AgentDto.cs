using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    /// <summary>
    /// Data Transfer Object for the Agent entity.
    /// Used to transfer camera data between the API and clients.
    /// </summary>
    public record AgentDto : IHaveIdWithSetter<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the camera.
        /// Corresponds to the database Id.
        /// </summary>
        public int Id { get; set; }

        public string ServerIp { get; set; } = String.Empty;

        public int AgentPort { get; set; }

        public int VncServerPort { get; set; }

        /// <summary>
        /// Provides a string representation of the CameraDto, primarily the CameraName.
        /// </summary>
        /// <returns>The name of the camera or an empty string if null.</returns>
        public override string ToString()
        {
            return ServerIp ?? String.Empty;
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>IP: {ServerIp ?? "N/A"}</small><br>" +
                $"<small>Agent port: {AgentPort}</small><br>" +
                $"<small>VNC port: {VncServerPort}</small>";
        }
    }
}
