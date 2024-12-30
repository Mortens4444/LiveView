using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IGridManagerView : IView
    {
        ComboBox CbGrids { get; }

        ListView LvGridCameras { get; }

        TextBox TbGridName { get; }

        ToolStripMenuItem TsmiChangeCameraTo { get; }
    }
}
