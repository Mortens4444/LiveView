using System.Drawing;

namespace LiveView.Interfaces
{
    public interface IControlCenterView : IView
    {
        Point HomeLocation { get; }

        void InitializeMouseUpdateTimer();
    }
}
