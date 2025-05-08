using Database.Interfaces;
using Database.Models;
using Mtf.Database.Interfaces;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IAddGroupView : IView
    {
        Group ParentGroup { get; }

        Group Group { get; set; }

        ComboBox CbEvents { get; }

        ListView LvAvaialableOperationsAndCameras { get; }

        ListView LvOperationsAndCameras { get; }

        Group GetGroup();

        UserEvent GetUserEvent();

        bool OperationsAndCamerasHasElementWithId(IHaveId<long> item);
    }
}
