using LiveView.Core.Dto;

namespace CameraForms.Interfaces
{
    public interface IDisplayProvider
    {
        DisplayDto GetDisplay(int? displayId);
    }
}