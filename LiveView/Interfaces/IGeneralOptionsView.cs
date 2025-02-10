using Mtf.Controls;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IGeneralOptionsView : IView
    {
        NumericUpDown NudFPS { get; }

        NumericUpDown NudRestartTemplate { get; }

        NumericUpDown NudMaximumTimeToWaitForNewPicture { get; }

        NumericUpDown NudMaximumDeflectionBetweenLiveViewAndRecorder { get; }

        NumericUpDown NudStatisticMessageAfterEveryMinutes { get; }

        NumericUpDown NudTimeBetweenCheckVideoServers { get; }

        NumericUpDown NudMaximumTimeToWaitForAVideoServerIs { get;  }

        CheckBox ChkReduceSequenceUsageOfNetworkAndCPU { get; }

        CheckBox ChkDeblock { get; }

        CheckBox ChkCloseSequenceApplicationOnFullScreenDisplayDevice { get; }

        CheckBox ChkLiveView { get; }

        CheckBox ChkThreading { get; }

        CheckBox ChkOpenMotionPopupWhenProgramStarts { get; }
        
        CheckBox ChkOpenControlCenterWhenProgramStarts { get; }

        CheckBox ChkUseCustomNoSignalImage { get; }

        CheckBox ChkVerboseDebugLogging { get; }

        CheckBox ChkIntegratedSecurity { get; }

        ComboBox CbKBD300ACOMPort { get; }

        ComboBox CbUsers { get; }

        ComboBox CbAutoLoadedTemplate { get; }

        TextBox TbDatabaseUsage { get; }

        TextBox TbDatabaseFolder { get; }

        TextBox TbDataSource { get; }

        TextBox TbUsername { get; }

        TextBox TbDatabaseName { get; }

        TextBox TbPassword { get; }
        
        NumericUpDown NudConnectionTimeout { get; }

        CheckBox ChkEncrypt { get; }

        CheckBox ChkPooling { get; }
        
        Label LblPassword { get; }

        MtfPictureBox PbStatus { get; }

        MtfPictureBox PbNoSignalImage { get; }

        RadioButton RbVerboseLogEveryEvents { get; }

        RadioButton RbVerboseLogOnlyErrors { get; }

        FolderBrowserDialog FolderBrowserDialog { get; }

        SaveFileDialog SaveFileDialog { get; }

        ComboBox CbWatchdogPort { get; }
    }
}
