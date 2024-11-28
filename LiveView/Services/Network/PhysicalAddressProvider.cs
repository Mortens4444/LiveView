using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace LiveView.Services.Network
{
    public static partial class PhysicalAddressProvider
    {
        private const int NoError = 0;
        private const int ErrorBadNetName = 67;
        private const int ErrorBufferOverflow = 111;
        private const int ErrorGenFailure = 31;
        private const int ErrorInvalidParameter = 87;
        private const int ErrorInvalidUserBuffer = 1784;
        private const int ErrorNotFound = 1168;


        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(uint DestIP, uint SrcIP, byte[] pMacAddr, ref int PhyAddrLen);

        public static PhysicalAddress Get(IPAddress ipAddress)
        {
            if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
            {
                var ipv6Address = ipAddress.ToString();
                var percentIndex = ipv6Address.LastIndexOf('%');
                if (percentIndex != -1)
                {
                    ipv6Address = ipv6Address.Substring(0, percentIndex);
                }
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $"/c netsh int ipv6 show neigh | findstr {ipv6Address}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                var process = Process.Start(processStartInfo);
                if (process != null)
                {
                    process.WaitForExit();
                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                    if (!String.IsNullOrEmpty(error))
                    {
                        throw new Exception(error);
                    }
                    var matches = GetMacRegex().Match(output);
                    if (matches.Success && matches.Groups.Count > 1)
                    {
                        return PhysicalAddress.Parse(matches.Groups[1].Value);
                    }
                }
            }

            // Check what family the ip is from <cref="http://msdn.microsoft.com/en-us/library/system.net.sockets.addressfamily.aspx"/>
            if (ipAddress.AddressFamily != AddressFamily.InterNetwork)
            {
                throw new ArgumentException("The remote system only supports IPv4 addresses");
            }

            var convertedIp = BitConverter.ToUInt32(ipAddress.GetAddressBytes(), 0);
            uint srcIp = 0;// BitConverter.ToUInt32(senderIpAddressStr.GetAddressBytes(), 0);
            var macByteArray = new byte[6];
            int length = macByteArray.Length;

            // Call the Win32 API SendARP <cref="http://msdn.microsoft.com/en-us/library/aa366358%28VS.85%29.aspx"/>
            int arpReply = SendARP(convertedIp, srcIp, macByteArray, ref length);
            if (arpReply != NoError)
            {
                switch (arpReply)
                {
                    case ErrorGenFailure:
                        throw new Exception("A device attached to the system is not functioning. This error is returned on Windows Server 2003 and earlier when an ARP reply to the SendARP request was not received. This error can occur if destination IPv4 address could not be reached because it is not on the same subnet or the destination computer is not operating.");
                    case ErrorInvalidParameter:
                        throw new Exception("One of the parameters is invalid. This error is returned on Windows Server 2003 and earlier if either the pMacAddr or PhyAddrLen parameter is a NULL pointer.");
                    case ErrorBadNetName:
                        throw new Exception("The network name cannot be found. This error is returned on Windows Vista and later when an ARP reply to the SendARP request was not received. This error occurs if the destination IPv4 address could not be reached.");
                    case ErrorBufferOverflow:
                        throw new Exception("The file name is too long. This error is returned on Windows Vista if the ULONG value pointed to by the PhyAddrLen parameter is less than 6, the size required to store a complete physical address.");
                    case ErrorInvalidUserBuffer:
                        throw new Exception("The supplied user buffer is not valid for the requested operation. This error is returned on Windows Server 2003 and earlier if the ULONG value pointed to by the PhyAddrLen parameter is zero.");
                    case ErrorNotFound:
                        throw new Exception("Element not found. This error is returned on Windows Vista if the the SrcIp parameter does not specify a source IPv4 address on an interface on the local computer or the INADDR_ANY IP address (an IPv4 address of 0.0.0.0).");
                    default:
                        throw new Win32Exception(arpReply);
                }
            }

            return new PhysicalAddress(macByteArray);
        }

        private static Regex GetMacRegex()
        {
            return new Regex(@"^[a-z0-9:]*\s*(([0-9-]{2}-){5}[0-9-]{2})", RegexOptions.Multiline);
        }
    }
}
