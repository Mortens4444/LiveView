using System;
using System.Net;

namespace LiveView.Services.Network
{
    public static class HostnameProvider
    {
        public static string Get(IPAddress ip)
        {
            try
            {
                var hostInfo = Dns.GetHostEntry(ip);
                return hostInfo.HostName;
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}
