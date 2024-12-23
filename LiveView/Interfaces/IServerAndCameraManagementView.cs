using Database.Enums;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IServerAndCameraManagementView : IView
    {
        TreeView ServersAndCameras { get; }

        Button BtnModify { get; }

        Button BtnRemove { get; }

        Button BtnProperties { get; }

        Button BtnMotionDetection { get; }

        Button BtnSyncronize { get; }

        SyncronizationMode GetSyncronizationMode();
    }
}
