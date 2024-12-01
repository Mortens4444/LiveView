using System;

namespace LiveView.Interfaces
{
    public interface IInvoker
    {
        void InvokeAction(Action action);
    }
}