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
        
        TextBox TbHttpStream { get; }
        
        NumericUpDown NudStreamId { get; }
        
        NumericUpDown NudPresetNumber { get; }
        
        NumericUpDown NudPatternNumber { get; }
        
        ComboBox CbFullscreenMode { get; }
        
        ComboBox CbPresetName { get; }
        
        ComboBox CbPatternName { get; }
    }
}
