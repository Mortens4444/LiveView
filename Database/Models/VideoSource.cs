using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class VideoSource : IHaveId<int>
    {
        public int Id { get; set; }

        public int AgentId { get; set; }

        public string Name { get; set; }

        public int Port { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
