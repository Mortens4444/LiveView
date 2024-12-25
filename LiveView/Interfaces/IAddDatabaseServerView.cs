using Database.Models;

namespace LiveView.Interfaces
{
    public interface IAddDatabaseServerView : IView
    {
        DatabaseServerDto GetDatabaseServerDto();
    }
}
