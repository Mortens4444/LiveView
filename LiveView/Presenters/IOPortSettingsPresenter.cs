using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class IOPortSettingsPresenter
    {
        private readonly IIOPortSettingsView ioPortSettingsView;
        private readonly IIOPortRepository ioPortRepository;

        public IOPortSettingsPresenter(IIOPortSettingsView ioPortSettingsView, IIOPortRepository ioPortRepository)
        {
            this.ioPortSettingsView = ioPortSettingsView;
            this.ioPortRepository = ioPortRepository;
        }
    }
}
