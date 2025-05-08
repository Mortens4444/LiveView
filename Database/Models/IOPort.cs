using Database.Enums;
using Mtf.Database.Interfaces;

namespace Database.Models
{
    public class IOPort : IHaveId<long>
    {
        public long Id { get; set; }

        public int DeviceId { get; set; }

        public int PortNum { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public PortDirection Direction { get; set; }

        public int State { get; set; }

        public int MinTriggerTime { get; set; }

        public int MaxCount { get; set; }

        public override string ToString()
        {
            return FriendlyName ?? Name;
        }
    }
}
