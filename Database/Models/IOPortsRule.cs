using Database.Interfaces;

namespace Database.Models
{
    public class IOPortsRule : IHaveId<long>
    {
        public long Id { get; set; }

        public int DeviceId { get; set; }

        public long OperationId { get; set; }

        public long EventId { get; set; }

        public int PortNum { get; set; }

        public bool ZeroSignaled { get; set; }
    }
}
