using Mtf.MessageBoxes.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IView : IInvoker
    {
        Control.ControlCollection Controls { get; }

        Color BackColor { get; set; }

        Point Location { get; set; }

        Size Size { get; set; }

        int Width { get; set; }

        int Height { get; set; }

        void Invalidate(bool invalidateChildren);

        void Invalidate();

        void Update();

        void Close();

        Form GetSelf();

        void SetLabelText(Label label, string text);

        bool ShowConfirm(string title, string message, Decide decide);

        void Show(Form form);

        bool ShowDialog(Form form);

        void ShowInfo(string title, string message);

        void ShowError(string title, string message);

        void ShowDebugError(Exception exception);

        void ShowError(Exception exception);

        bool HasItemWithId(ListView listview, long id);

        ListView.ListViewItemCollection GetItems(ListView listView);

        ListView.SelectedListViewItemCollection GetSelectedItems(ListView listView);

        void AddToItems(ListView listView, params ListViewItem[] itemsToView);

        void AddToItems(ListView.ListViewItemCollection items, params ListViewItem[] itemsToView);

        TType GetSelectedItem<TType>(ComboBox comboBox);

        void AddItems<TType>(ComboBox comboBox, IEnumerable<TType> items);

        void SelectByIndex(ComboBox comboBox, int index = 0);

        void RemoveAllItem(ListView listView);

        void RemoveSelectedItems(ListView listView);

        void AddNodes(TreeNode treeNode, IEnumerable<TreeNode> nodes);

        void Expand(TreeNode treeNode);

        void ExpandAll(TreeNode treeNode);

        TreeNode GetSelectedItem(TreeView treeView);

        void Invalidate(Control control);

        void RefreshUI();
    }
}
