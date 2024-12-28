using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface ICameraRepository<TModel> : IRepository<TModel>
    {
        string SelectCameraName(int cameraId);
    }
}