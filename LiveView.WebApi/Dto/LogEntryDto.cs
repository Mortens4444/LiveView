using Database.Enums;
using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record LogEntryDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long UserId { get; set; }

        public long? OperationId { get; set; }

        public long? EventId { get; set; }

        public string OtherInformation { get; set; }

        public LogType LogType => OperationId.HasValue ? LogType.Operation : EventId.HasValue ? LogType.Event : LogType.Error;

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>{Id}</strong><br>" +
                $"<small>Date: {Date}</small><br>" +
                $"<small>LogType: {LogType}</small><br>" +
                $"<small>UserId: {UserId}</small><br>" +
                $"<small>OperationId: {OperationId}</small><br>" +
                $"<small>EventId: {EventId}</small><br>" +
                $"<small>OtherInformation: {OtherInformation}</small>";
        }
    }
}
