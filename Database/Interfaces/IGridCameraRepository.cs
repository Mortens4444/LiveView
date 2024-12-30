using Mtf.Database.Interfaces;
using System.Collections.ObjectModel;

namespace Database.Interfaces
{
    public interface IGridCameraRepository<TModel> : IRepository<TModel>
    {
        void DeleteCamerasOfGrid(long id);

        ReadOnlyCollection<TModel> GetCombinedGridCameras(long gridId);
    }
}
