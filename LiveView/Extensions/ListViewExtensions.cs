using Database.Interfaces;
using System;
using System.Collections.Generic;
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

        public static bool Any(this ListView.ListViewItemCollection items, Func<ListViewItem, bool> predicate)
        {
            foreach (ListViewItem item in items)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static void SelectAll(this ListView.ListViewItemCollection items)
        {
            foreach (ListViewItem item in items)
            {
                item.Selected = true;
            }
        }

        public static void SelectAll(this ListViewGroup group)
        {
            foreach (ListViewItem item in group.Items)
            {
                item.Selected = true;
            }
        }

        public static void AddItems<T>(this ListView listView, IEnumerable<T> items, Func<T, ListViewItem> itemConverter, bool clearItems = true)
        {
            if (clearItems)
            {
                listView.Items.Clear();
            }

            var lvItems = new List<ListViewItem>();
            foreach (var item in items)
            {
                lvItems.Add(itemConverter(item));
            }

            listView.Items.AddRange(lvItems.ToArray());
        }
    }
}
