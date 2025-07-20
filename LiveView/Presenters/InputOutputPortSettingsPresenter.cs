using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Enums;
using Mtf.Windows.Forms.Extensions;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class InputOutputPortSettingsPresenter : BasePresenter
    {
        private IInputOutputPortSettingsView view;
        private readonly IUserEventRepository userEventRepository;
        private readonly IInputOutputPortRepository inputOutputPortRepository;
        private readonly IInputOutputPortLogRepository inputOutputPortsLogRepository;
        private readonly IInputOutputPortRuleRepository inputOutputPortsRuleRepository;
        private readonly ILogger<InputOutputPortSettings> logger;

        public InputOutputPortSettingsPresenter(InputOutputPortSettingsPresenterDependencies dependencies)
            : base(dependencies)
        {
            userEventRepository = dependencies.UserEventRepository;
            inputOutputPortRepository = dependencies.InputOutputPortRepository;
            inputOutputPortsLogRepository = dependencies.InputOutputPortsLogRepository;
            inputOutputPortsRuleRepository = dependencies.InputOutputPortsRuleRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IInputOutputPortSettingsView;
        }

        public void AddRule()
        {
            var userEvent = view.CbOperationOrEvent.SelectedItem as UserEvent;
            var port = view.CbInputOutputDevice.SelectedItem as InputOutputPort;
            inputOutputPortsRuleRepository.Insert(new InputOutputPortRule
            {
                DeviceId = port.DeviceId,
                PortNum = port.PortNum,
                ZeroSignalled = view.ChkZeroSignalled.Checked,
                UserEventId = userEvent.Id
            });
            logger.LogInfo(IODeviceManagementPermissions.Update, "I/O device '{0}' rule has been created.", port.Name);
        }

        public override void Load()
        {
            var events = userEventRepository.SelectAll();
            view.AddItems(view.CbOperationOrEvent, events);

            var inputOutputPorts = inputOutputPortRepository.SelectAll();
            view.LvInputOutputDevices.AddItems(inputOutputPorts, (InputOutputPort port) =>
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

            view.AddItems(view.CbInputOutputDevice, inputOutputPorts);
            view.AddItems(view.CbOutputInputOutputPort, inputOutputPorts.Where(p => p.Direction == PortDirection.Output));
        }

        public void ChangePortSettings()
        {
            if (ShowDialog<InputOutputPortEditor>())
            {

            }
        }

        public void DeleteRules()
        {
            foreach (ListViewItem item in view.LvInputOutputPortRules.SelectedItems)
            {
                if (item.Tag is InputOutputPortRule inputOutputPortsRule)
                {
                    inputOutputPortsRuleRepository.Delete(inputOutputPortsRule.Id);
                }
            }
            logger.LogInfo(IODeviceManagementPermissions.Update, "I/O device rules have been deleted.");

            Load();            
        }
    }
}
