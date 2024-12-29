using LiveView.Dto;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IDisplayPropertiesView : IView
    {
        DisplayDto Display { get; }

        TextBox TbDisplayDeviceSziltechID { get; }

        TextBox TbDisplayDeviceIdentifier { get; }

        TextBox TbDisplayName { get; }

        TextBox TbAdapterName { get; }

        TextBox TbTopLeftCoordinate { get; }

        TextBox TbResolution { get; }

        TextBox TbWorkPlaceArea { get; }

        CheckBox ChkShowSequences { get; }

        CheckBox ChkRemovable { get; }

        CheckBox ChkAttachedToDesktop { get; }

        CheckBox ChkDefaultFullScreenDevice { get; }
    }
}
