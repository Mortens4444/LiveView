namespace Database.Interfaces
{
    public interface ICameraRepository<TModel> : IRepository<TModel>
    {
        string SelectCameraName(int cameraId);
    }
}