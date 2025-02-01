using Database.Interfaces;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class IOPortEditorPresenter : BasePresenter
    {
        private IIOPortEditorView view;
        private readonly IIOPortRepository ioPortRepository;
        private readonly ILogger<IOPortEditor> logger;

        public IOPortEditorPresenter(IOPortEditorPresenterDependencies dependencies)
            : base(dependencies)
        {
            ioPortRepository = dependencies.IOPortRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IIOPortEditorView;
        }

        public override void Load()
        {
            view.TbFriendlyName.Text = view.IOPort.FriendlyName;
            view.NudMaxSignalPerDay.Value = view.IOPort.MaxCount;
            view.NudMinTriggerTime.Value = view.IOPort.MinTriggerTime;
        }

        public void Save()
        {
            view.IOPort.FriendlyName = view.TbFriendlyName.Text;
            view.IOPort.MaxCount = (int)view.NudMaxSignalPerDay.Value;
            view.IOPort.MinTriggerTime = (int)view.NudMinTriggerTime.Value;
            ioPortRepository.Update(view.IOPort);
        }
    }
}
