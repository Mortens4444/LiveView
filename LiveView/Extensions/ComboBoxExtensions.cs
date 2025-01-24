using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Extensions
{
    public static class ComboBoxExtensions
    {
        public static void SelectFirst(this ComboBox comboBox)
        {
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        public static void AddItems(this ComboBox comboBox, IEnumerable<object> items)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items.ToArray());
        }

        public static void AddItemsAndSelectFirst(this ComboBox comboBox, IEnumerable<object> items)
        {
            comboBox.AddItems(items);
            comboBox.SelectFirst();
        }
    }
}
