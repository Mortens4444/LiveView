using System.Windows.Forms;

namespace LiveView.Controls
{
    public class CustomPanel : Panel
    {
        private const int WM_EXITSIZEMOVE = 0x0232;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_EXITSIZEMOVE)
            {
                Invalidate();
                Update();
            }

            base.WndProc(ref m);
        }
    }
}
