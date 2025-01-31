using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IUserAndGroupManagementView : IView
    {
        Button BtnNewGroup { get; }

        Button BtnNewUser { get; }

        Button BtnModify { get; }

        Button BtnRemove { get; }

        TreeView TvUsersAndGroups { get; }
    }
}
