using Database.Models;
using LiveView.Models.Network;

namespace LiveView.Interfaces
{
    public interface IAddVideoServerView : IView
    {
        void AddToServerSelector(HostDiscoveryResult result);

        ServerDto GetServerDto();

        void LoadData(Server server);
    }
}
