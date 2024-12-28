using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IUserAndGroupManagementView : IView
    {
        TreeView TvUsersAndGroups { get; }
    }
}
