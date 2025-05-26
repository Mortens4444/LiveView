using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class Agent : IHaveId<long>
    {
        public long Id { get; set; }

        public string ServerIp { get; set; }

        public int AgentPort { get; set; }

        public int VncServerPort { get; set; }

        public override string ToString()
        {
            return $"{ServerIp}:{AgentPort}";
        }
    }
}
