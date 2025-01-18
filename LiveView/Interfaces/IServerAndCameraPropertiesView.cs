using Database.Models;
using Mtf.Controls;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IServerAndCameraPropertiesView : IView
    {
        Server Server { get; }

        MtfListView LvCameraList { get; }

        MtfListView LvHardwareInformation { get; }

        SaveFileDialog SaveFileDialog { get; }

        TextBox TbPassword { get; }

        TextBox TbWindowsUsername { get; }

        TextBox TbWindowsPassword { get; }
    }
}
