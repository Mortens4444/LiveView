using Database.Interfaces;
using System.Windows.Forms;


namespace LiveView.Extensions
{
    public static class ListViewExtensions
    {
        public static bool HasElementWithGuid<TModelType>(this ListView listView, string guid)
            where TModelType : IHaveGuid
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
    }
}
