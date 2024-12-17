using System;

namespace Database.Models
{
    public class Log
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long UserId { get; set; }

        public long? OperationId { get; set; }

        public long? EventId { get; set; }

        public long? LanguageElementId { get; set; }

        public string OtherInformation { get; set; }

        public string Checksum { get; set; }
    }
}
