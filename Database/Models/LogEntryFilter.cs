using Database.Enums;
using System;

namespace Database.Models
{
    public class LogEntryFilter
    {
        public LogType LogType { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
        
        public ushort MaxRows { get; set; }

        public string MessagePart { get; set; }

        public string OtherInformationPart { get; set; }

        public ulong Offset { get; set; }
    }
}
