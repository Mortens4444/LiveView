using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IServerAndCameraManagementView : IView
    {
        TreeView ServersAndCameras { get; }
    }
}
