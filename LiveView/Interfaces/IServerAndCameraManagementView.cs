using System.Collections.Generic;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IServerAndCameraManagementView : IView
    {
        void ShowServerNodes(IEnumerable<TreeNode> serverNodes);

        TreeNode GetSelectedItem();
    }
}
