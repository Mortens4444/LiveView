using Database.Models;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IAddGroupView : IView
    {
        ComboBox CbEvents { get; }

        ListView LvAvaialableOperationsAndCameras { get; }

        ListView LvOperationsAndCameras { get; }

        Group GetGroup();
    }
}
