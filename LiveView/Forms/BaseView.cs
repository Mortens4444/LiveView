#define SET_PRESENTER_WITH_DYNAMIC

using Database.Enums;
using Database.Interfaces;
using LiveView.Extensions;
using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services.Coloring;
using Microsoft.Extensions.DependencyInjection;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Enums;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        protected readonly IServiceProvider serviceProvider;
        protected PermissionManager<Database.Models.User> permissionManager;

        protected BasePresenter Presenter { get; private set; }
        private readonly Type presenterType;
        protected bool colorize = true;

        public BaseView() : this(null, typeof(BasePresenter))
        {
        }

        public BaseView(IServiceProvider serviceProvider, Type presenterType)
        {
            if (!DesignMode)
            {
                permissionManager = serviceProvider?.GetRequiredService<PermissionManager<Database.Models.User>>();
                Load += BaseView_Load;
            }
            this.presenterType = presenterType;
            this.serviceProvider = serviceProvider;
        }

        private void BaseView_Load(object sender, EventArgs e)
        {
            if (colorize)
            {
                Colorize();
            }
        }

        private void Colorize()
        {
            var generalOptionsRepository = serviceProvider?.GetRequiredService<IGeneralOptionsRepository>();
            var useCustomColors = generalOptionsRepository?.Get(Setting.UseCustomControlColors, false) ?? false;
            if (useCustomColors)
            {
                var colorizeControlsService = serviceProvider?.GetRequiredService<ColorizeControlsService>();
                
                colorizeControlsService.ColorizeControl(this, Setting.GroupBoxBackgroundColor, Setting.GroupBoxForeColor, Color.FromArgb(50, 50, 50), Color.White);
                colorizeControlsService.ColorizeControls(Controls);
            }
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

        public void ShowDebugError(Exception exception)
        {
            DebugErrorBox.Show(exception);
        }

        public void ShowError(Exception exception)
        {
            ErrorBox.Show(exception);
        }

        public Form GetSelf()
        {
            return this;
        }

        public T GetSelf<T>() where T : class
        {
            return this as T;
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

        public void AddToItems(ListView.ListViewItemCollection items, params ListViewItem[] itemsToView)
        {
            items.AddRange(itemsToView);
        }

        public TType GetSelectedItem<TType>(ComboBox comboBox)
        {
            return (TType)comboBox.SelectedItem;
        }

        public void AddItems<TType>(ComboBox comboBox, IEnumerable<TType> items)
        {
            comboBox.Items.Clear();
            foreach (var item in items)
            {
                comboBox.Items.Add(item);
            }
        }

        public bool HasItemWithId(ListView listview, long id)
        {
            return listview.HasElementWithId(id);
        }

        public bool HasItemWithTag(ListView listview, object value)
        {
            return listview.HasElementWithTag(value);
        }

        public void SelectByIndex(ComboBox comboBox, int index = 0)
        {
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = index;
            }
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

        public void Invalidate(Control control)
        {
            control.Invalidate();
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
                        if (!(permissionManager.CurrentUser?.HasPermission(WindowManagementPermissions.Resize) ?? false))
                        {
                            return;
                        }
                    }
                    else if (command == SC_MOVE)
                    {
                        if (!(permissionManager.CurrentUser?.HasPermission(WindowManagementPermissions.Move) ?? false))
                        {
                            return;
                        }
                    }
                }

                if (m.Msg == WM_CLOSE)
                {
                    if (!(permissionManager.CurrentUser?.HasPermission(WindowManagementPermissions.Close) ?? false))
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
#if SET_PRESENTER_WITH_DYNAMIC
                SetPresenterWithDynamic();
#else
                SetPresenterWithReflection();
#endif

                Presenter?.SetLocationAndSize();
            }
        }

#if SET_PRESENTER_WITH_DYNAMIC
        private void SetPresenterWithDynamic()
        {
            try
            {
                dynamic presenter = serviceProvider?.GetRequiredService(presenterType);
                Presenter = presenter as BasePresenter;
                presenter.SetView(this);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }
#else
        private void SetPresenterWithReflection()
        {
            var presenter = serviceProvider?.GetRequiredService(presenterType);
            Presenter = presenter as BasePresenter;
            var setViewMethod = presenterType.GetMethod(nameof(Presenter.SetView));
            setViewMethod?.Invoke(presenter, new object[] { this });
        }
#endif

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Presenter?.SetLocationAndSize();
        }

        public void RefreshUI()
        {
            Invalidate(true);
            Update();
        }

        public static void MoveSelectedItems(ListView listView, bool moveDown)
        {
            var selectedItems = listView.SelectedItems.Cast<ListViewItem>()
                .OrderBy(item => moveDown ? -item.Index : item.Index)
                .ToList();

            if (selectedItems.Count == 0 ||
                (moveDown && selectedItems.Last().Index == listView.Items.Count - 1) ||
                (!moveDown && selectedItems.First().Index == 0))
            {
                return;
            }

            foreach (var item in selectedItems)
            {
                int currentIndex = item.Index;
                listView.Items.Remove(item);
                listView.Items.Insert(currentIndex + (moveDown ? 1 : -1), item);
            }

            foreach (var item in selectedItems)
            {
                item.Selected = true;
            }

            foreach (ListViewItem item in listView.Items)
            {
                var number = item.Index + 1;
                item.Text = number.ToString();
                if (item.Tag is IHaveNumber haveNumber)
                {
                    haveNumber.Number = number;
                }
            }
        }
    }
}