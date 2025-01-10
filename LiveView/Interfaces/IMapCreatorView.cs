using Mtf.Controls;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IMapCreatorView : IView
    {
        MovableSizablePanel PTemplate { get; }

        Panel PCanvas { get; }

        ComboBox CbMap { get; }

        RichTextBox RtbComment { get; }

        ContextMenuStrip CmsObjectMenu { get; }

        FolderBrowserDialog FolderBrowserDialog { get; }
    }
}
