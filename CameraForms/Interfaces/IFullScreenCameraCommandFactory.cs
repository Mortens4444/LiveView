using LiveView.Core.Interfaces;
using System.Collections.ObjectModel;

namespace CameraForms.Interfaces
{
    public interface IFullScreenCameraCommandFactory
    {
        ReadOnlyCollection<ICommand> CreateCommands(string messages);
    }
}