using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record ServerDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public string? IpAddress { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? MacAddress { get; set; }

        public string? Hostname { get; set; }

        public string? DongleSn { get; set; }

        public string? SerialNumber { get; set; }

        public string? WinUser { get; set; }

        public string? WinPass { get; set; }

        public bool StartInMotionPopup { get; set; }

        public override string ToString() => Hostname ?? String.Empty;

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Hostname ?? "N/A"}</strong><br>" +
                $"<small>IP: {IpAddress ?? "N/A"}</small><br>" +
                $"<small>Username: {Username}</small><br>" +
                $"<small>Password: {Password}</small>";
        }
    }
}
