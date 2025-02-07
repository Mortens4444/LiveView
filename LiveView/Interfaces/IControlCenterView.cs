using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IControlCenterView : IBaseDisplayView
    {
        Label LblSequenceName { get; }

        Label LblNumberOfCameras { get; }

        Label LblGridName { get; }

        Label LblGridNumber { get; }

        Label LblSecondsLeft { get; }

        Point HomeLocation { get; }

        Panel PDisplayDevices { get; }

        void InitializeMouseUpdateTimer(Panel panel);

        ListView LvCameras { get; }

        ListView LvSequences { get; }

        ListView LvTemplates { get; }

        ComboBox CbAgents { get; }
    }
}
