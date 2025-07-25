using Database.Models;
using LiveView.Dto;
using LiveView.Models.Network;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IAddVideoServerView : IView
    {
        void AddToServerSelector(HostDiscoveryResult result);

        VideoServerDto GetServerDto();

        void LoadData(VideoServer server);

        TextBox TbModel { get; }

        TextBox TbSziltechSerialNumber { get; }
    }
}
