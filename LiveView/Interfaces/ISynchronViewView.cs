using AxVIDEOCONTROL4Lib;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface ISynchronViewView : IView
    {
        AxVideoPicture AxVideoPicture1 { get; }

        AxVideoPicture AxVideoPicture2 { get; }

        AxVideoPicture AxVideoPicture3 { get; }

        AxVideoPicture AxVideoPicture4 { get; }

        TrackBar TbSpeed { get; }

        DateTimePicker DtpImageDate { get; }

        NumericUpDown NudHour { get; }

        NumericUpDown NudMinute { get; }

        NumericUpDown NudSecond { get; }

        CheckBox ChkOsd { get; }

        ToolStripMenuItem TsmiChangeCameraTo { get; }
    }
}
