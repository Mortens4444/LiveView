using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LiveView.Services
{
    public static class ParentChildToolStripMenuItemBuilder
    {
        public static void PopulateMenuItems<TParent, TChild>(
            ToolStripMenuItem rootItem,
            IEnumerable<TParent> parents,
            Func<TParent, string> parentTextSelector,
            Func<TParent, IEnumerable<TChild>> childSelector,
            Func<TChild, string> childTextSelector,
            EventHandler leafItemClickHandler)
        {
            rootItem.DropDownItems.Clear();
            foreach (var parent in parents)
            {
                var parentItem = new ToolStripMenuItem(parentTextSelector(parent))
                {
                    Tag = parent
                };

                var children = childSelector(parent);
                foreach (var child in children)
                {
                    var childItem = new ToolStripMenuItem(childTextSelector(child))
                    {
                        Tag = child
                    };
                    childItem.Click += leafItemClickHandler;
                    parentItem.DropDownItems.Add(childItem);
                }

                rootItem.DropDownItems.Add(parentItem);
            }
        }
    }
}
