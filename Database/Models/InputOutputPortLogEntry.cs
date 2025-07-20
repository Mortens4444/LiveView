using Mtf.Extensions.Interfaces;
using System;

namespace Database.Models
{
    public class InputOutputPortLogEntry : IHaveId<int>
    {
        public int Id { get; set; }

        public int DeviceId { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public int PortNum { get; set; }

        public int State { get; set; }
    }
}
