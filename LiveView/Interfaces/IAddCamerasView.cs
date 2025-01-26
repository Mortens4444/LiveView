using System.Windows.Forms;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IAddCamerasView : IView
    {
        ComboBox Servers { get; }

        ListView ServerCameras { get; }

        ListView CamerasToView { get; }

        bool CamerasToViewHasElementWithGuid(string cameraGuid);
    }
}
