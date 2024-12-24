using Database.Enums;
using System;

namespace Database.Models
{
    public class LogEntry
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long UserId { get; set; }

        public long? OperationId { get; set; }

        public long? EventId { get; set; }

        public long? LanguageElementId { get; set; }

        public string OtherInformation { get; set; }

        public LogType LogType
        {
            get
            {
                if (OperationId != null)
                {
                    return LogType.Operation;
                }
                if (EventId != null)
                {
                    return LogType.Event;
                }
                return LogType.Error;
            }
        }
    }
}
