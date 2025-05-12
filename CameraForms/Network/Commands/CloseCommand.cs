using LiveView.Core.Interfaces;
using System;
using System.Windows.Forms;

namespace CameraForms.Network.Commands
{
    public class CloseCommand : ICommand
    {
        private readonly Form form;

        public CloseCommand(Form form)
        {
            this.form = form;
        }

        public void Execute()
        {
            if (form.InvokeRequired)
            {
                form.Invoke((Action)(() => form.Close()));
            }
            else
            {
                form.Close();
            }
        }
    }
}
