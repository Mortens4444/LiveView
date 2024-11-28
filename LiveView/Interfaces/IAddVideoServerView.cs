using Database.Models;

namespace LiveView.Interfaces
{
    public interface IAddVideoServerView : IView
    {
        ServerDto GetServer();
    }
}
