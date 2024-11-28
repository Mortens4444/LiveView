using System.Net;

namespace LiveView.Services.Network
{
    public static class LocalIpAddressChecker
    {
        public static bool IsLocal(string hostName)
        {
            try
            {
                var hostIPs = Dns.GetHostAddresses(hostName);
                var localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                foreach (var hostIP in hostIPs)
                {
                    if (IPAddress.IsLoopback(hostIP))
                    {
                        return true;
                    }
                    foreach (var localIP in localIPs)
                    {
                        if (hostIP.Equals(localIP))
                        {
                            return true;
                        }
                    }
                }
            }
            catch { }
            return false;
        }
    }

}
