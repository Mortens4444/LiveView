using Mtf.Controls;
using System.Drawing;

namespace LiveView.Extensions
{
    public static class PanelExtensions
    {
        public static MovableSizablePanel Clone(this MovableSizablePanel sourcePanel, Point location)
        {
            return new MovableSizablePanel
            {
                Size = sourcePanel.Size,
                BackColor = sourcePanel.BackColor,
                BorderStyle = sourcePanel.BorderStyle,
                CanMove = true,
                CanSize = sourcePanel.CanSize,
                Location = location
            };
        }
    }
}
