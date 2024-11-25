using System.ComponentModel;
using System.Windows.Forms;


namespace LiveView.Extensions
{
    public static class ListViewExtensions
    {
        public static bool HasElementWithKey(this ListView listView, string key)
        {
            var findItems = listView.Items.Find(key, false);
            return findItems.Length > 0;
        }
    }
}
