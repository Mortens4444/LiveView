using Database.Interfaces;
using System.Windows.Forms;


namespace LiveView.Extensions
{
    public static class ListViewExtensions
    {
        public static bool HasElementWithGuid(this ListView listView, string guid)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (((IHaveGuid)item.Tag).Guid == guid)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool HasElementWithId(this ListView listView, long id)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (((IHaveId<long>)item.Tag).Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
