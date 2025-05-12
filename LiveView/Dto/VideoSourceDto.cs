using LiveView.Core.Extensions;
using System;
using System.Net.Sockets;

namespace LiveView.Dto
{
    public class VideoSourceDto : IEquatable<VideoSourceDto>
    {
        private string endPoint;

        public Socket Socket { get; set; }

        public string Name { get; set; }

        public Database.Models.Agent Agent { get; private set; }
        
        public string EndPoint
        {
            get => endPoint;
            set
            {
                endPoint = value;
                var connectionData = value.GetIpAddressAndPortFromEndPoint();
                Agent = new Database.Models.Agent
                {
                    ServerIp = connectionData.Item1,
                    AgentPort = connectionData.Item2
                };
            }
        }

        public bool Equals(VideoSourceDto other)
        {
            if (other == null)
            {
                return false;
            }

            return Name == other.Name && Agent.ServerIp == other.Agent.ServerIp;
        }

        public override bool Equals(object obj)
        {
            if (obj is VideoSourceDto other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Name?.GetHashCode() ?? 0);
                hash = hash * 23 + (Agent.ServerIp?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Agent.ServerIp}:{Agent.AgentPort}";
        }
    }
}
