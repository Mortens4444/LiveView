using System;

namespace LiveView.Models.Network
{
    public class HostDiscoveryResult
    {
        public string IpAddress { get; set; } = String.Empty;

        public string Hostname { get; set; } = String.Empty;

        public string MacAddress { get; set; } = String.Empty;

        public string Manufacturer { get; set; } = String.Empty;

        public string NetworkInterfaceName { get; set; } = String.Empty;

        public string NetworkInterfaceType { get; set; } = String.Empty;

        public string NetworkInterfaceDescription { get; set; } = String.Empty;

        public string Speed { get; set; } = String.Empty;

        public override string ToString()
        {
            return IpAddress;
        }
    }
}
