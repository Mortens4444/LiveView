using AxVIDEOCONTROL4Lib;
using System;

namespace LiveView.Interfaces
{
    public interface IVideoServerView
    {
        AxVideoServer GetVideoServerControl();

        void InvokeAction(Action action);
    }
}
