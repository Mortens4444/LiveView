using LiveView.Interfaces;
using Mtf.MessageBoxes.Enums;
using Mtf.MessageBoxes;
using System;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace LiveView.Forms
{
    public partial class BaseView : Form, IView
    {
        public BaseView()
        {
            InitializeComponent();
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
    }
}
