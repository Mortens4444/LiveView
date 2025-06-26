using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record BarcodeScanOptionsDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public int CustomIn { get; set; }

        public int CustomOut { get; set; }

        public int LcidIn { get; set; }

        public int LcidOut { get; set; }

        public int MaxDelay { get; set; }

        public int SelectedComPort { get; set; }
        
        public bool SerialScanner { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>SelectedComPort: {SelectedComPort}</small>";
        }
    }
}
