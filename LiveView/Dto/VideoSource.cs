using System;
using System.Net.Sockets;

namespace LiveView.Dto
{
    public class VideoSource
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
                var connectionData = value.Split(':');
                ServerIp = connectionData[0];
                ServerPort = Convert.ToUInt16(connectionData[1]);
            }
        }

        public override string ToString()
        {
            return $"{Name} - {ServerIp}:{ServerPort}";
        }
    }
}
