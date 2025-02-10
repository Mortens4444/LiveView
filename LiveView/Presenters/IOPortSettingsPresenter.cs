using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Enums;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class IOPortSettingsPresenter : BasePresenter
    {
        private IIOPortSettingsView view;
        private readonly IEventRepository eventRepository;
        private readonly IIOPortRepository ioPortRepository;
        private readonly IIOPortsLogRepository ioPortsLogRepository;
        private readonly IIOPortsRuleRepository ioPortsRuleRepository;
        private readonly ILogger<IOPortSettings> logger;

        public IOPortSettingsPresenter(IOPortSettingsPresenterDependencies dependencies)
            : base(dependencies)
        {
            eventRepository = dependencies.EventRepository;
            ioPortRepository = dependencies.IOPortRepository;
            ioPortsLogRepository = dependencies.IOPortsLogRepository;
            ioPortsRuleRepository = dependencies.IOPortsRuleRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IIOPortSettingsView;
        }

        public void AddRule()
        {
            var @event = view.CbOperationOrEvent.SelectedItem as Event;
            var port = view.CbIODevice.SelectedItem as IOPort;
            ioPortsRuleRepository.Insert(new IOPortsRule
            {
                DeviceId = port.DeviceId,
                PortNum = port.PortNum,
                ZeroSignaled = view.ChkZeroSignalled.Checked,
                EventId = @event.Id
            });
            logger.LogInfo(IODeviceManagementPermissions.Update, "I/O device '{0}' rule has been created.", port.Name);
        }

        public override void Load()
        {
            var events = eventRepository.SelectAll();
            view.AddItems(view.CbOperationOrEvent, events);

            var ioPorts = ioPortRepository.SelectAll();
            view.LvIODevices.AddItems(ioPorts, (IOPort port) =>
            {
                var result = new ListViewItem(port.DeviceId.ToString())
                {
                    Tag = port
                };
                result.SubItems.Add(port.PortNum.ToString());
                result.SubItems.Add(port.Name);
                result.SubItems.Add(port.FriendlyName);
                result.SubItems.Add(port.MaxCount.ToString());
                result.SubItems.Add(port.MinTriggerTime.ToString());
                return result;
            });

            view.AddItems(view.CbIODevice, ioPorts);
            view.AddItems(view.CbOutputIOPort, ioPorts.Where(p => p.Direction == PortDirection.Output));
        }

        public void ChangePortSettings()
        {
            if (ShowDialog<IOPortEditor>())
            {

            }
        }

        public void DeleteRules()
        {
            foreach (ListViewItem item in view.LvIOPortRules.SelectedItems)
            {
                if (item.Tag is IOPortsRule ioPortsRule)
                {
                    ioPortsRuleRepository.Delete(ioPortsRule.Id);
                }
            }
            logger.LogInfo(IODeviceManagementPermissions.Update, "I/O device rules have been deleted.");

            Load();            
        }
    }
}
