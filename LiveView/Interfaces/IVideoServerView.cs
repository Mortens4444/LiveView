using AxVIDEOCONTROL4Lib;

namespace LiveView.Interfaces
{
    public interface IVideoServerView : IInvoker
    {
        AxVideoServer AxVideoServer { get; }
    }
}
