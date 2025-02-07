using Database.Enums;
using System;

namespace Database.Models
{
    public class LogEntryFilter
    {
        public int LogType { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
        
        public int MaxRows { get; set; }

        public string OtherInformationPart { get; set; }

        public long Offset { get; set; }

        public long UserId { get; set; }
    }
}
