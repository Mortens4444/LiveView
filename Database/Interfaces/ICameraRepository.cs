using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface ICameraRepository<TModel> : IRepository<TModel>
    {
        void DeleteCamerasOfServer(long serverId);

        string SelectCameraName(long cameraId);
    }
}