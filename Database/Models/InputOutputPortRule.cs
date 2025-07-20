using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class InputOutputPortRule : IHaveId<int>
    {
        public int Id { get; set; }

        public int DeviceId { get; set; }

        public int OperationId { get; set; }

        public int UserEventId { get; set; }

        public int PortNum { get; set; }

        public bool ZeroSignalled { get; set; }
    }
}
