using LiveView.Core.Enums;
using System;

namespace LiveView.Core.CustomEventArgs
{
    public class ListChangedEventArgs<T> : EventArgs
    {
        public T Item { get; }

        public T OldItem { get; }

        public int Index { get; }

        public ChangeType ChangeType { get; }

        public ListChangedEventArgs(T item, ChangeType changeType, int index, T oldItem = default)
        {
            Item = item;
            ChangeType = changeType;
            Index = index;
            OldItem = oldItem;
        }
    }
}
