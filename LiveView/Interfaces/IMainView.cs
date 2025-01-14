using System;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IMainView : IView
    {
        PictureBox PbMap { get; }

        ToolTip TtHint { get; }

        ToolStripStatusLabel TsslServerData { get; }

        IntPtr GetHandle();

        void SetCursorPosition();

        void SetUptime(TimeSpan osUptime, TimeSpan appUptime);
    }
}
