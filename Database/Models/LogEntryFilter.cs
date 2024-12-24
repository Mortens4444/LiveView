using Database.Enums;
using System;

namespace Database.Models
{
    public class LogEntryFilter
    {
        public LogType LogType { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }
        
        public ushort MaxRows { get; set; }

        public string MessagePart { get; set; }

        public string OtherInformationPart { get; set; }

        public ulong Offset { get; set; }
    }
}
