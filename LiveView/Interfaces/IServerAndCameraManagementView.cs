using Database.Models;

namespace LiveView.Interfaces
{
    public interface IServerAndCameraManagementView : IView
    {
        void AddServer(Server server);
    }
}
