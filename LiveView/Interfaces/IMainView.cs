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

        IntPtr GetHandle();

        void SetCursorPosition();

        void SetUptime(TimeSpan osUptime, TimeSpan appUptime);

        TextBox TbUsername { get; }

        TextBox TbPassword { get; }

        TextBox TbUsername2 { get; }

        TextBox TbPassword2 { get; }
    }
}
