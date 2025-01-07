using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace LiveView.Core.Services
{
    public static class NetUtils
    {
        public static IEnumerable<string> GetLocalIPAddresses(AddressFamily addressFamily)
        {
            return Dns.GetHostEntry(Dns.GetHostName())
                      .AddressList
                      .Where(ip => ip.AddressFamily == addressFamily)
                      .Select(ip => ip.ToString());
        }
    }
}
