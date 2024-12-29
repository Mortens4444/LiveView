using Mtf.Controls;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IGeneralOptionsView : IView
    {
        NumericUpDown NudFPS { get; }

        NumericUpDown NudRestartTemplate { get; }

        NumericUpDown NudDatabasePort { get; }

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

        CheckBox ChkUseCustomNoSignalImage { get; }

        CheckBox ChkVerboseDebugLogging { get; }

        CheckBox ChkUseWatchDog { get; }

        ComboBox CbKBD300ACOMPort { get; }

        ComboBox CbUsers { get; }

        TextBox TbDatabaseUsage { get; }

        TextBox TbDatabaseFolder { get; }

        TextBox TbDatabaseServerIp { get; }

        TextBox TbPassword { get; }

        TextBox TbUsername { get; }

        TextBox TbDatabaseName { get; }

        MtfPictureBox PbStatus { get; }

        MtfPictureBox PbNoSignalImage { get; }

        RadioButton RbVerboseLogEveryEvents { get; }

        RadioButton RbVerboseLogOnlyErrors { get; }

        FolderBrowserDialog FolderBrowserDialog { get; }
    }
}
