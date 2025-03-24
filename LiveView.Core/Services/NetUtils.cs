using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace LiveView.Core.Services
{
    public static class NetUtils
    {
        public static bool AreTheSameIp(string serverIp1, string serverIp2)
        {
            if (serverIp1 == serverIp2)
            {
                return true;
            }

            var localIps = GetLocalIPAddresses(AddressFamily.InterNetwork);
            if ((localIps.Any(ip => ip == serverIp1) || serverIp1 == "0.0.0.0") && (localIps.Any(ip => ip == serverIp2) || serverIp2 == "0.0.0.0"))
            {
                return true;
            }

            return false;
        }

        public static IEnumerable<string> GetLocalIPAddresses(AddressFamily addressFamily)
        {
            return Dns.GetHostEntry(Dns.GetHostName())
                      .AddressList
                      .Where(ip => ip.AddressFamily == addressFamily)
                      .Select(ip => ip.ToString());
        }
    }
}
