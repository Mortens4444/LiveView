using Mtf.Extensions.Interfaces;
using System.Net;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record DatabaseServerDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public string IpAddress { get; set; }

        public string EncryptedUsername { get; set; }

        public string EncryptedPassword { get; set; }

        public string MacAddress { get; set; }

        public string Hostname { get; set; }

        public string DbName { get; set; }

        public int DbPort { get; set; }

        public override string ToString()
        {
            return Hostname;
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Hostname ?? "N/A"}</strong><br>" +
                $"<small>IP: {IpAddress ?? "N/A"}</small><br>" +
                $"<small>Username: {EncryptedUsername}</small><br>" +
                $"<small>Password: {EncryptedPassword}</small>";
        }
    }
}
