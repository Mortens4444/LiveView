using Mtf.MessageBoxes.Enums;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IView : IInvoker
    {
        void Close();

        Form GetSelf();

        bool ShowConfirm(string title, string message, Decide decide);

        void Show(Form form);

        bool ShowDialog(Form form);

        void ShowInfo(string title, string message);

        void ShowError(string title, string message);

        void ShowError(Exception exception);

        ListView.ListViewItemCollection GetItems(ListView listView);

        ListView.SelectedListViewItemCollection GetSelectedItems(ListView listView);

        void AddToItems(ListView listView, params ListViewItem[] itemsToView);

        TType GetSelectedItem<TType>(ComboBox comboBox);

        void AddItems<TType>(ComboBox comboBox, ReadOnlyCollection<TType> items);

        void SelectByIndex(ComboBox comboBox, int index = 0);

        void RemoveAllItem(ListView listView);

        void RemoveSelectedItems(ListView listView);
    }
}
