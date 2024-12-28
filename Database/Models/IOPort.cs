using Database.Interfaces;

namespace Database.Models
{
    public class IOPort : IHaveId<long>
    {
        public long Id { get; set; }

        public int DeviceId { get; set; }

        public int PortNum { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public int Direction { get; set; }

        public int State { get; set; }

        public int MinTriggerTime { get; set; }

        public int MaxCount { get; set; }
    }
}
