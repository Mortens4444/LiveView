using System;

namespace LiveView.Interfaces
{
    public interface IMainView : IView
    {
        IntPtr GetHandle();

        void SetCursorPosition();

        void SetUptime(TimeSpan osUptime, TimeSpan appUptime);
    }
}
