using LiveView.Enums;
using LiveView.Interfaces;

namespace LiveView.Services.Moxa
{
    public class MonitorSelector
    {
        private readonly IMoxaTtlOutput ttl;

        public MonitorSelector(IMoxaTtlOutput ttlOutput)
        {
            ttl = ttlOutput;
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
