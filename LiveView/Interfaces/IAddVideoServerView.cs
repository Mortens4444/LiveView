using Database.Models;
using LiveView.Models.Network;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IAddVideoServerView : IView
    {
        void AddToServerSelector(HostDiscoveryResult result);

        ServerDto GetServerDto();

        void LoadData(Server server);

        TextBox TbModel { get; }

        TextBox TbSziltechSerialNumber { get; }
    }
}
