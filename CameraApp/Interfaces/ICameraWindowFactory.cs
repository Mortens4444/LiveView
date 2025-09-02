using CameraForms.Dto;
using System.Windows.Forms;

namespace CameraApp.Interfaces
{
    public interface ICameraWindowFactory
    {
        Form Create(CameraLaunchContext context);
    }
}
