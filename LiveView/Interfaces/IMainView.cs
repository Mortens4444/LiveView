using Mtf.Controls;
using System;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IMainView : IView
    {
        MtfPictureBox PbMap { get; }

        ToolTip TtHint { get; }

        ToolStripStatusLabel TsslServerData { get; }

        ToolStripStatusLabel TsslJoystick { get; }

        IntPtr GetHandle();

        void SetCursorPosition();

        void SetUptime(TimeSpan osUptime, TimeSpan appUptime);

        TextBox TbUsername { get; }

        PasswordBox TbPassword { get; }

        Label LblPassword { get; }

        GroupBox GbPrimaryLogon { get; }

        Button BtnLoginLogoutPrimary { get; }
    }
}
