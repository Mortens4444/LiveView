using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IAddCamerasView : IView
    {
        ComboBox VideoServers { get; }

        ListView ServerCameras { get; }

        ListView CamerasToView { get; }

        bool CamerasToViewHasElementWithGuid(string cameraGuid);
    }
}
