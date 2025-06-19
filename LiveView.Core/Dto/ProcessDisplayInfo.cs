using Mtf.Extensions;
using Mtf.Network;
using Mtf.Network.Services;
using System;

namespace LiveView.Core.Dto
{
    public class ProcessDisplayInfo
    {
        public string HostInfo { get; private set; } = String.Empty;
        
        public int ProcessId { get; private set; }

        public string DisplayId { get; private set; } = String.Empty;

        public ProcessDisplayInfo(DisplayDto display, Client client)
        {
            HostInfo = client.Socket?.LocalEndPoint?.GetEndPointInfo(NetUtils.GetLocalIPAddresses);
            ProcessId = Services.ProcessUtils.GetProcessId();
            DisplayId = display?.Id ?? String.Empty;
        }
    }
}
