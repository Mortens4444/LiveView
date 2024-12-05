using System;

namespace LiveView.Interfaces
{
    public interface IMainView : IView
    {
        IntPtr GetHandle();
        void SetCursorPosition();
    }
}
