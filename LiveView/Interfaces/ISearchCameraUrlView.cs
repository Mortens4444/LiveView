using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface ISearchCameraUrlView : IView
    {
        ComboBox CbIpAddress { get; }

        ComboBox CbCameraUrls { get; }

        ComboBox CbManufacturer { get; }

        TextBox TbUsername { get; }

        TextBox TbPassword { get; }

        NumericUpDown NudChannel { get; }

        NumericUpDown NudTimeout { get; }

        NumericUpDown NudWidth { get; }

        NumericUpDown NudHeight { get; }
    }
}
