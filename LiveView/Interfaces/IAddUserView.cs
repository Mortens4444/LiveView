using Database.Models;

namespace LiveView.Interfaces
{
    public interface IAddUserView : IView
    {
        User GetUser();
    }
}
