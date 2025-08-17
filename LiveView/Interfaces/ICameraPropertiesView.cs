using Database.Models;
using Mtf.Controls;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface ICameraPropertiesView : IView
    {
        Camera Camera { get; }

        TextBox TbCameraName { get; }

        TextBox TbCameraGuid { get; }

        TextBox TbCameraIpAddress { get; }

        TextBox TbCameraUsername { get; }

        PasswordBox TbCameraPassword { get; }
        
        TextBox TbStreamUrl { get; }

        TextBox TbCameraFunctionCallback { get; }

        TextBox TbCameraFunctionCallbackParameters { get; }

        NumericUpDown NudStreamId { get; }
        
        NumericUpDown NudPresetNumber { get; }
        
        NumericUpDown NudPatternNumber { get; }
        
        ComboBox CbCameraFunctionType { get; }

        ComboBox CbFullscreenMode { get; }

        ComboBox CbPresetName { get; }
        
        ComboBox CbPatternName { get; }

        MtfListView LvCameraFunctions { get; }

        OpenFileDialog OpenFileDialog { get; }

        SaveFileDialog SaveFileDialog { get; }

        ComboBox CbVideoSources { get; }

        Label LblVideoSources { get; }

        PictureBox PbStreamUrl { get; }
    }
}
