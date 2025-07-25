using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record UserDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public string EncryptedUsername { get; set; }

        public string EncryptedPassword { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }
        
        public string Email { get; set; }

        public string Phone { get; set; }
        
        public string LicensePlate { get; set; }
        
        public string Barcode { get; set; }
        
        public string OtherInformation { get; set; }
        
        public byte[] Image { get; set; }
        
        public int SecondaryLogonPriority { get; set; }

        public int NeededSecondaryLogonPriority { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>Id: {Id}</strong><br>" +
                $"<small>Username: {EncryptedUsername}</small><br>" +
                $"<small>Password: {EncryptedPassword}</small><br>" +
                $"<small>FullName: {FullName}</small><br>" +
                $"<small>Address: {Address}</small>";
        }
    }
}
