using Database.Interfaces;

namespace Database.Models
{
    public class Agent : IHaveId<long>
    {
        public long Id { get; set; }

        public long VideoSourceId { get; set; }

        public int Port { get; set; }
    }
}
