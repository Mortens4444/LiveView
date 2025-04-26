using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace LiveView.Agent.Maui
{
    public static class NetworkHelper
    {
        public static IPAddress? GetDeviceIpAddressPreferPrivate(AddressFamily addressFamily = AddressFamily.InterNetwork, string preferedIpAddress = "192.168.")
        {
            IPAddress? fallbackIp = null;

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                {
                    var ipProperties = networkInterface.GetIPProperties();
                    if (ipProperties?.UnicastAddresses != null)
                    {
                        foreach (var ipInfo in ipProperties.UnicastAddresses)
                        {
                            if (ipInfo.Address.AddressFamily == addressFamily)
                            {
                                if (!IPAddress.IsLoopback(ipInfo.Address))
                                {
                                    var ipString = ipInfo.Address.ToString();

                                    if (ipString.StartsWith(preferedIpAddress))
                                    {
                                        return ipInfo.Address;
                                    }

                                    if (fallbackIp == null)
                                    {
                                        fallbackIp = ipInfo.Address;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return fallbackIp;
        }
    }
}
