using LiveView.Interfaces;
using System;

namespace LiveView.Services.Moxa
{
    public class TtlOutput : IMoxaTtlOutput
    {
        public void SetOutput(int channel, bool high)
        {
            Console.WriteLine($"TTL{channel} = {(high ? "HIGH" : "LOW")}");
        }
    }
}
