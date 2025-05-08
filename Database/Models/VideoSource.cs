using Mtf.Database.Interfaces;

namespace Database.Models
{
    public class VideoSource : IHaveId<long>
    {
        public long Id { get; set; }

        public long AgentId { get; set; }

        public string Name { get; set; }

        public int Port { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
