using Mtf.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IPersonalOptionsView : IView
    {
        ComboBox CbLanguages { get; }

        CheckBox ChkUseCustomColors { get; }

        RadioButton RbDisplayedName { get; }

        RadioButton RbIpAddress { get; }

        RadioButton RbNone { get; }

        NumericUpDown NudLargeFontSize { get; }

        NumericUpDown NudSmallFontSize { get; }

        MtfPictureBox PbFontColor { get; }

        MtfPictureBox PbFontShadowColor { get; }

        Font CameraFont { get; }

        ColorDialog CdColorPicker { get; }

        FontDialog FdFontPicker { get; }

        Label LblTest { get; }

        void SetOriginalTexts();
    }
}
