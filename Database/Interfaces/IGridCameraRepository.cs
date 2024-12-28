using System.Collections.ObjectModel;

namespace Database.Interfaces
{
    public interface IGridCameraRepository<TModel> : IRepository<TModel>
    {
        ReadOnlyCollection<TModel> GetCombinedGridCameras(long gridId);
    }
}
