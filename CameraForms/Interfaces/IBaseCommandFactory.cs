using LiveView.Core.Interfaces;
using System.Collections.ObjectModel;

namespace CameraForms.Interfaces
{
    public interface IBaseCommandFactory
    {
        ReadOnlyCollection<ICommand> CreateCommands(string messages);
    }
}