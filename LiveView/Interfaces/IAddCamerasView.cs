using Database.Models;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IAddCamerasView : IView
    {
        void AddAllCameras();

        void AddSelectedCamera();

        void AddToItemsToView(params ListViewItem[] itemsToView);

        bool CamerasToViewHasElementWithGuid(string cameraGuid);

        void GetCameras();

        ListView.ListViewItemCollection GetServerCameras();

        ListView.SelectedListViewItemCollection GetServerSelectedCameras();

        void LoadServers(ReadOnlyCollection<Server> servers);

        void RemoveAllCamera();

        void RemoveSelectedCamera();
    }
}
