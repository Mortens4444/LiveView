using Database.Models;
using LiveView.Models.Network;

namespace LiveView.Interfaces
{
    public interface IAddDatabaseServerView : IView
    {
        void AddToServerSelector(HostDiscoveryResult result);

        DatabaseServerDto GetDatabaseServerDto();

        void LoadData(DatabaseServer server);
    }
}
