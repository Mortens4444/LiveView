using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Services
{
    public class CustomMenuRenderer : ToolStripRenderer
    {
        private readonly Color backgroundColor;
        private readonly Color selectedColor;
        private readonly Color textColor;

        public CustomMenuRenderer(Color backgroundColor, Color selectedColor, Color textColor)
        {
            this.backgroundColor = backgroundColor;
            this.selectedColor = selectedColor;
            this.textColor = textColor;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.AffectedBounds);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var rect = new Rectangle(Point.Empty, e.Item.Size);

            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(selectedColor), rect);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(backgroundColor), rect);
            }

            if (e.Item is ToolStripMenuItem menuItem && menuItem.DropDown.Visible)
            {
                menuItem.DropDown.BackColor = backgroundColor;
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = textColor;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            if (e.Image != null)
            {
                e.Graphics.DrawImage(e.Image, e.ImageRectangle);
            }
        }
    }
}
