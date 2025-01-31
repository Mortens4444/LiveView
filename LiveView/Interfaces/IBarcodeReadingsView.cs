using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IBarcodeReadingsView : IView
    {
        ListView LvScans { get; }
    }
}
