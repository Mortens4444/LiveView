using Mtf.Controls;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IAutoCreateWizardView : IView
    {
        ListView LeftSide { get; }

        ListView RightSide { get; }

        ComboBox CbGrids { get; }

        ComboBox CbX { get; }

        CheckBox ChkCreateSequences { get; }

        TextBox TbGridNamePrefix { get; }

        TextBox TbGridNamePostfix { get; }

        TextBox TbSequenceNamePrefix { get; }

        TextBox TbSequenceNamePostfix { get; }

        NumericUpDown NudSecondsToShow { get; }

        MtfPictureBox PbCheck { get; }

        ImageList ImageList { get; }
    }
}
