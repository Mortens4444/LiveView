using Mtf.Models;
using System;
using System.Windows.Forms;

namespace Mtf.Extensions
{
    public static class ControlExtensions
    {
        public static void AddControl(this Control container, Control control, GridCamera gridCamera)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (container is TableLayoutPanel tableLayoutPanel)
            {
                if (gridCamera != null)
                {
                    tableLayoutPanel.AddControl(control, gridCamera);
                }
                else
                {
                    container.Controls.Add(control);
                }
            }
            else
            {
                container.Controls.Add(control);
            }
        }
    }
}
