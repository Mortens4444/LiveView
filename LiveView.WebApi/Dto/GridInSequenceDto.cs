using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record GridInSequenceDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public long SequenceId { get; set; }

        public long GridId { get; set; }

        public int TimeToShow { get; set; }

        public int Number { get; set; }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>GridId: {GridId}</small><br>" +
                $"<small>SequenceId: {SequenceId}</small><br>" +
                $"<small>TimeToShow: {TimeToShow}</small><br>" +
                $"<small>Number: {Number}</small>";
        }
    }
}
