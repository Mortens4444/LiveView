using Database.Models;
using Mtf.Database.Interfaces;
using System.Collections.ObjectModel;

namespace Database.Interfaces
{
    public interface IGridCameraRepository : IRepository<GridCamera>
    {
        void DeleteCamerasOfGrid(long id);

        ReadOnlyCollection<GridCamera> GetCombinedGridCameras(long gridId);
    }
}
