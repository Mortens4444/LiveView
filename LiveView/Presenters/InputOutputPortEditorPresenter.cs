using Database.Interfaces;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Enums;

namespace LiveView.Presenters
{
    public class InputOutputPortEditorPresenter : BasePresenter
    {
        private IInputOutputPortEditorView view;
        private readonly IInputOutputPortRepository inputOutputPortRepository;
        private readonly ILogger<InputOutputPortEditor> logger;

        public InputOutputPortEditorPresenter(InputOutputPortEditorPresenterDependencies dependencies)
            : base(dependencies)
        {
            inputOutputPortRepository = dependencies.InputOutputPortRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IInputOutputPortEditorView;
        }

        public override void Load()
        {
            view.TbFriendlyName.Text = view.InputOutputPort.FriendlyName;
            view.NudMaxSignalPerDay.Value = view.InputOutputPort.MaxCount;
            view.NudMinTriggerTime.Value = view.InputOutputPort.MinTriggerTime;
        }

        public void Save()
        {
            view.InputOutputPort.FriendlyName = view.TbFriendlyName.Text;
            view.InputOutputPort.MaxCount = (int)view.NudMaxSignalPerDay.Value;
            view.InputOutputPort.MinTriggerTime = (int)view.NudMinTriggerTime.Value;
            inputOutputPortRepository.Update(view.InputOutputPort);
            logger.LogInfo(IODeviceManagementPermissions.Update, "I/O device '{0}' has been changed.", view.InputOutputPort.Name);
        }
    }
}
