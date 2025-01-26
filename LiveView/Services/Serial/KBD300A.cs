using Mtf.MessageBoxes;
using Mtf.Serial.CustomEventArgs;
using Mtf.Serial.SerialDevices;

namespace LiveView.Services.Serial
{
    public class KBD300A
    {
        private PelcoKbd300A pelcoKbd300A;

        public KBD300A(string comPort)
        {
            pelcoKbd300A = new PelcoKbd300A(comPort);
            pelcoKbd300A.CommandArrived += PelcoKbd300A_CommandArrived;
        }

        private void PelcoKbd300A_CommandArrived(object sender, CommandArrivedEventArgs e)
        {
            switch (e.Command)
            {
                default:
                    InfoBox.Show("Information", $"Unknown message arrived: {e.Command}");
                    break;
            }
        }
    }
}
