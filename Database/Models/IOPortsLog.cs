using Database.Interfaces;
using System;

namespace Database.Models
{
    public class IOPortsLog : IHaveId<long>
    {
        public long Id { get; set; }

        public int DeviceId { get; set; }

        public long UserId { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public int PortNum { get; set; }

        public int State { get; set; }
    }
}
