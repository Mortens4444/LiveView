using System;
using System.Net.Sockets;

namespace LiveView.Dto
{
    public class VideoSourceDto : IEquatable<VideoSourceDto>
    {
        private string endPoint;

        public Socket Socket { get; set; }

        public string Name { get; set; }

        public string ServerIp { get; private set; }
        
        public ushort ServerPort { get; private set; }

        public string EndPoint
        {
            get => endPoint;
            set
            {
                endPoint = value;
                var connectionData = value.Split(new char[] { ':', ' ' });
                ServerIp = connectionData[0];
                ServerPort = Convert.ToUInt16(connectionData[1]);
            }
        }

        public bool Equals(VideoSourceDto other)
        {
            if (other == null)
            {
                return false;
            }

            return Name == other.Name && ServerIp == other.ServerIp;
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
                hash = hash * 23 + (ServerIp?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {ServerIp}:{ServerPort}";
        }
    }
}
