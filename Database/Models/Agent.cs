using Database.Interfaces;

namespace Database.Models
{
    public class Agent : IHaveId<long>
    {
        public long Id { get; set; }

        public string ServerIp { get; set; }

        public int Port { get; set; }

        public string VideoCaptureSourceName { get; set; }
    }
}
