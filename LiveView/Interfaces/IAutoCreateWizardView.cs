using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IAutoCreateWizardView : IView
    {
        ListView LeftSide { get; }

        ListView RightSide { get; }
    }
}
