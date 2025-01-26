using System.Net.Sockets;

namespace LiveView.Dto
{
    public class SequenceProcessInfo
    {
        public Socket Socket { get; set; }

        public long UserId { get; set; }

        public long? SequenceId { get; set; }

        public long DisplayId { get; set; }

        public bool IsMdi { get; set; }

        public int ProcessId { get; set; }
    }
}
