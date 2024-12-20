using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Enums;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class BaseView : Form, IView
    {
        private const int WM_EXITSIZEMOVE = 0x0232;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int WM_CLOSE = 0x0010;
        private const int SC_SIZE = 0xF000;
        private const int SC_MOVE = 0xF010;

        protected readonly PermissionManager permissionManager;

        protected BasePresenter Presenter { get; private set; }

        public BaseView() : this(null)
        {
        }

        public BaseView(PermissionManager permissionManager)
        {
            this.permissionManager = permissionManager;
        }

        public void InvokeAction(Action action)
        {
            Invoke(action);
        }

        public void Show(Form form)
        {
            form.Show();
        }

        public bool ShowDialog(Form form)
        {
            var dialogResult = form.ShowDialog();
            return dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes;
        }

        public bool ShowConfirm(string title, string message, Decide decide = Decide.No)
        {
            var dialogResult = ConfirmBox.Show(title, message, decide);
            return dialogResult == DialogResult.Yes;
        }

        public void ShowInfo(string title, string message)
        {
            InfoBox.Show(title, message);
        }

        public void ShowError(string title, string message)
        {
            ErrorBox.Show(title, message);
        }

        public void ShowError(Exception exception)
        {
            ErrorBox.Show(exception);
        }

        public Form GetSelf()
        {
            return this;
        }

        public ListView.ListViewItemCollection GetItems(ListView listView)
        {
            return listView.Items;
        }

        public ListView.SelectedListViewItemCollection GetSelectedItems(ListView listView)
        {
            return listView.SelectedItems;
        }

        public void AddToItems(ListView listView, params ListViewItem[] itemsToView)
        {
            listView.Items.AddRange(itemsToView);
        }

        public TType GetSelectedItem<TType>(ComboBox comboBox)
        {
            return (TType)comboBox.SelectedItem;
        }

        public void AddItems<TType>(ComboBox comboBox, ReadOnlyCollection<TType> items)
        {
            foreach (var item in items)
            {
                comboBox.Items.Add(item);
            }
        }

        public void SelectByIndex(ComboBox comboBox, int index = 0)
        {
            comboBox.SelectedIndex = 0;
        }

        public void SetLabelText(Label label, string text)
        {
            label.Text = text;
        }

        public void RemoveAllItem(ListView listView)
        {
            listView.Items.Clear();
        }

        public void RemoveSelectedItems(ListView listView)
        {
            for (int i = listView.SelectedItems.Count - 1; i >= 0; i--)
            {
                listView.Items.Remove(listView.SelectedItems[i]);
            }
        }

        public void AddNodes(TreeNode treeNode, IEnumerable<TreeNode> nodes)
        {
            treeNode.Nodes.Clear();
            foreach (var node in nodes)
            {
                treeNode.Nodes.Add(node);
            }
        }

        public void Expand(TreeNode treeNode)
        {
            treeNode.Expand();
        }

        public void ExpandAll(TreeNode treeNode)
        {
            treeNode.ExpandAll();
        }

        public TreeNode GetSelectedItem(TreeView treeView)
        {
            return treeView.SelectedNode;
        }

        protected override void WndProc(ref Message m)
        {
            if (permissionManager != null)
            {
                if (m.Msg == WM_SYSCOMMAND)
                {
                    var command = m.WParam.ToInt32() & 0xFFF0;
                    if (command == SC_SIZE)
                    {
                        if (!permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Resize))
                        {
                            return;
                        }
                    }
                    else if (command == SC_MOVE)
                    {
                        if (!permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Move))
                        {
                            return;
                        }
                    }
                }

                if (m.Msg == WM_CLOSE)
                {
                    if (!permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Close))
                    {
                        return;
                    }
                }
            }

            if (m.Msg == WM_EXITSIZEMOVE)
            {
                if (!DesignMode)
                {
                    Presenter?.OnResizeOrMoveEnd();
                }
            }

            base.WndProc(ref m);
        }

        protected void SetPresenter(BasePresenter presenter)
        {
            Presenter = presenter;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                Presenter?.SetLocationAndSize();
            }
        }
    }
}