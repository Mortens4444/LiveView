using LiveView.Models.Network;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LiveView.Services.Network
{
    public static class HostDiscoveryService
    {
        private const string LocalSubstring = "127.0.0";
        private static readonly OuiLookupService ouiLookupService = new OuiLookupService();

        public delegate void HostDiscoveredEventHandler(HostDiscoveryResult result);
        public static event HostDiscoveredEventHandler HostDiscovered;

        public static void Discovery()
        {
            var hostname = Dns.GetHostName();
            var ips = Dns.GetHostEntry(hostname);

            foreach (var ip in ips.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    DiscoverHost(ip);
                }
                else
                {
                    var subnet = ip.ToString().Substring(0, ip.ToString().LastIndexOf('.'));
                    if (subnet != LocalSubstring)
                    {
                        Parallel.For(1, 254, (int i) =>
                        {
                            DiscoverHost(IPAddress.Parse($"{subnet}.{i}"));
                        });
                    }
                }
            }
            if (ips.AddressList.Length == 1 && ips.AddressList[0].ToString().StartsWith(LocalSubstring))
            {
                Parallel.For(1, 255, (int i) =>
                {
                    DiscoverHost(IPAddress.Parse($"{"192.168.0"}.{i}"));
                });
            }
        }

        private static void DiscoverHost(IPAddress ipAddress)
        {
            try
            {
                var ipAddressStr = ipAddress.ToString();
                var result = new HostDiscoveryResult { IpAddress = ipAddressStr };

                var hostname = HostnameProvider.Get(ipAddress);
                if (!String.IsNullOrEmpty(hostname))
                {
                    result.Hostname = hostname;

                    var physicalAddress = PhysicalAddressProvider.Get(ipAddress);
                    result.MacAddress = PhysicalAddressToStringConverter.ToString(physicalAddress);
                    result.Manufacturer = ouiLookupService.Lookup(result.MacAddress);

                    if (LocalIpAddressChecker.IsLocal(ipAddressStr))
                    {
                        var networkInterface = NetworkInterface.GetAllNetworkInterfaces().ToList()
                            .Find(nic => nic.GetIPProperties().UnicastAddresses
                            .Any(ipInfo => ipInfo.Address.ToString() == ipAddressStr));

                        if (networkInterface != null)
                        {
                            result.NetworkInterfaceName = networkInterface.Name;
                            result.NetworkInterfaceType = networkInterface.NetworkInterfaceType.ToString();
                            result.NetworkInterfaceDescription = networkInterface.Description;
                            result.Speed = HumanReadableValueFormatter.FormatValue(networkInterface.Speed, true);
                        }
                    }
                    HostDiscovered?.Invoke(result);
                }
            }
            catch { }
        }
    }

}
