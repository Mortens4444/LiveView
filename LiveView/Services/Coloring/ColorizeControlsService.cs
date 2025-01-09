using Database.Enums;
using Database.Interfaces;
using Mtf.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Services.Coloring
{
    public class ColorizeControlsService
    {
        private readonly IGeneralOptionsRepository generalOptionsRepository;

        public ColorizeControlsService(IGeneralOptionsRepository generalOptionsRepository)
        {
            this.generalOptionsRepository = generalOptionsRepository;
        }

        public void ColorizeControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                ColorizeControls(control.Controls);

                if (control is ListView)
                {
                    ColorizeControl(control, Setting.ListViewBackgroundColor, Setting.ListViewForeColor, Color.FromArgb(90, 90, 90), Color.White);
                    if (control is MtfListView mtfListView)
                    {
                        mtfListView.AlternatingColorEven = Color.FromArgb(60, 60, 60);
                        mtfListView.AlternatingColorOdd = Color.FromArgb(40, 40, 40);
                    }
                }

                if (control is TreeView)
                {
                    ColorizeControl(control, Setting.TreeViewBackgroundColor, Setting.TreeViewForeColor, Color.FromArgb(90, 90, 90), Color.White);
                }

                if (control is GroupBox)
                {
                    ColorizeControl(control, Setting.GroupBoxBackgroundColor, Setting.GroupBoxForeColor, Color.FromArgb(40, 40, 40), Color.White);
                }

                if (control is Panel)
                {
                    ColorizeControl(control, Setting.GroupBoxBackgroundColor, Setting.GroupBoxForeColor, Color.FromArgb(40, 40, 40), Color.White);
                }

                if (control is Button)
                {
                    ColorizeControl(control, Setting.GroupBoxBackgroundColor, Setting.GroupBoxForeColor, Color.FromArgb(60, 60, 60), Color.White);
                }

                if (control is PictureBox)
                {
                    ColorizeControl(control, Setting.PictureBoxBackgroundColor, Setting.PictureBoxForeColor, Color.FromArgb(90, 90, 90), Color.White);
                }

                if (control is TextBox)
                {
                    ColorizeControl(control, Setting.TextBoxBackgroundColor, Setting.TextBoxForeColor, Color.FromArgb(100, 100, 100), Color.White);
                }

                if (control is RichTextBox)
                {
                    ColorizeControl(control, Setting.RichTextBoxBackgroundColor, Setting.RichTextBoxForeColor, Color.FromArgb(100, 100, 100), Color.White);
                }

                if (control is NumericUpDown)
                {
                    ColorizeControl(control, Setting.NumericUpDownBackgroundColor, Setting.NumericUpDownForeColor, Color.FromArgb(100, 100, 100), Color.White);
                }

                if (control is ComboBox)
                {
                    ColorizeControl(control, Setting.ComboBoxBackgroundColor, Setting.ComboBoxForeColor, Color.FromArgb(100, 100, 100), Color.White);
                }

                if (control is LinkLabel linkLabel)
                {
                    var color = Color.LightBlue;
                    linkLabel.LinkColor = generalOptionsRepository.Get(Setting.LinkColor, color);
                }

                if (control is MenuStrip menuStrip)
                {
                    var backColor = generalOptionsRepository.Get(Setting.MenuBackgroundColor, Color.FromArgb(70, 70, 70));
                    var selectedColor = generalOptionsRepository.Get(Setting.MenuSelectedColor, Color.FromArgb(90, 90, 90));
                    var foreColor = generalOptionsRepository.Get(Setting.MenuForegroundColor, Color.White);

                    menuStrip.BackColor = backColor;
                    menuStrip.ForeColor = foreColor;
                    menuStrip.Renderer = new CustomMenuRenderer(backColor, selectedColor, foreColor);

                    ApplyColorsToMenuItems(menuStrip.Items, backColor, foreColor);
                }

                if (control is StatusStrip)
                {
                    ColorizeControl(control, Setting.StatusStripBackgroundColor, Setting.StatusStripForeColor, Color.FromArgb(70, 70, 70), Color.White);
                }
            }
        }

        private void ColorizeControl(Control control, Setting backgroundColor, Setting foreColor, Color defaultBackgroundColor, Color defaultForeColor)
        {
            control.BackColor = generalOptionsRepository.Get(backgroundColor, defaultBackgroundColor);
            control.ForeColor = generalOptionsRepository.Get(foreColor, defaultForeColor);
        }

        private void ApplyColorsToMenuItems(ToolStripItemCollection items, Color backColor, Color foreColor)
        {
            foreach (ToolStripItem item in items)
            {
                item.BackColor = backColor;
                item.ForeColor = foreColor;
                if (item is ToolStripMenuItem toolStripMenuItem)
                {
                    toolStripMenuItem.DropDownOpening += (sender, e) =>
                    {
                        toolStripMenuItem.DropDown.BackColor = backColor;
                        toolStripMenuItem.DropDown.ForeColor = foreColor;
                    };
                }

                if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0)
                {
                    ApplyColorsToMenuItems(menuItem.DropDownItems, backColor, foreColor);
                }
            }
        }
    }
}
