using LiveView.Enums;
using LiveView.Interfaces;
using System;

namespace LiveView.Services.Moxa
{
    public class MonitorSelector
    {
        private readonly IMoxaTtlOutput ttl;

        public MonitorSelector(IMoxaTtlOutput ttlOutput)
        {
            ttl = ttlOutput;
        }

        public void SelectMonitors(LiveViewMachine liveView)
        {
            switch (liveView)
            {
                case LiveViewMachine.LiveViewMachine1:
                    SelectMonitors(MonitorAddress.Monitor01, MonitorAddress.Monitor04, MonitorAddress.Monitor07, MonitorAddress.Monitor10);
                    break;
                case LiveViewMachine.LiveViewMachine2:
                    SelectMonitors(MonitorAddress.Monitor02, MonitorAddress.Monitor05, MonitorAddress.Monitor08, MonitorAddress.Monitor11);
                    break;
                case LiveViewMachine.LiveViewMachine3:
                    SelectMonitors(MonitorAddress.Monitor03, MonitorAddress.Monitor06, MonitorAddress.Monitor09, MonitorAddress.Monitor12);
                    break;
                default:
                    throw new NotSupportedException($"LiveView is not supported: {liveView}");
            }
        }

        public void SelectMonitors(params MonitorAddress[] addresses)
        {
            foreach (var address in addresses)
            {
                SelectMonitor(address);
            }
        }

        public void SelectMonitor(MonitorAddress address)
        {
            var addressValue = (int)address;

            for (var bit = 0; bit < 4; bit++)
            {
                var isHigh = ((addressValue >> bit) & 1) == 1;
                ttl.SetOutput(bit, isHigh);
            }
        }
    }
}
