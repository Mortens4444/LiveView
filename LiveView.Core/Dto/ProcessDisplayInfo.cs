using LiveView.Core.Services;
using Mtf.Network;
using Mtf.Network.Extensions;
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
            HostInfo = client.Socket?.LocalEndPoint?.GetEndPointInfo();
            ProcessId = ProcessUtils.GetProcessId();
            DisplayId = display?.Id ?? String.Empty;
        }
    }
}
