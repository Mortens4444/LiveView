using Database.Enums;
using Mtf.Extensions.Interfaces;
using System;

namespace Database.Models
{
    public class LogEntry : IHaveId<long>
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public int? OperationId { get; set; }

        public int? EventId { get; set; }

        public string OtherInformation { get; set; }

        public LogType LogType => OperationId.HasValue ? LogType.Operation : EventId.HasValue ? LogType.Event : LogType.Error;
    }
}
