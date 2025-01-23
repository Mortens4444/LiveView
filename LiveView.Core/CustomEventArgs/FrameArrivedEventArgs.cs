using System;
using System.Drawing;

namespace LiveView.Core.CustomEventArgs
{
    public class FrameArrivedEventArgs : EventArgs
    {
        public FrameArrivedEventArgs(Image frame)
        {
            Frame = frame;
        }

        public Image Frame { get; private set; }
    }
}
