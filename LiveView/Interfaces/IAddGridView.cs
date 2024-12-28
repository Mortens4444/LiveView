using Mtf.Controls.x86;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IAddGridView : IView
    {
        NumericUpDown NudNumberOfRows { get; }

        NumericUpDown NudNumberOfColumns { get; }

        NumericUpDown NudPixelsFromRight { get; }
        
        NumericUpDown NudPixelsFromBottom { get; }

        NumericUpDown NudInitialRow { get; }

        NumericUpDown NudClosingRow { get; }

        NumericUpDown NudInitialColumn { get; }

        NumericUpDown NudClosingColumn { get; }

        ComboBox CbDisplays { get; }

        ComboBox CbGrids { get; }

        TextBox TbGridName { get; }

        ToolStripStatusLabel TsslNumberOfCameras { get; }

        Panel PMain {  get; }

        Panel PMiniDesign { get; }

        CheckBox ChkConnectToCamera { get; }

        bool IsVideoConnected { get; }

        AxVideoPlayerWindow AxVideoPlayerWindow { get; }
    }
}
