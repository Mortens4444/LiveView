using Database.Models;
using Mtf.Database.Interfaces;
using System.Collections.ObjectModel;

namespace Database.Interfaces;

public interface IGridCameraRepository : IRepository<GridCamera, int>
{
    void DeleteCamerasOfGrid(int id);

    ReadOnlyCollection<GridCamera> GetCombinedGridCameras(int gridId);
}
