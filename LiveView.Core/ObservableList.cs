using LiveView.Core.CustomEventArgs;
using LiveView.Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LiveView.Core
{
    public class ObservableList<T> : IEnumerable<T>, IReadOnlyList<T>
    {
        private readonly List<T> list = new List<T>();

        public event EventHandler<ListChangedEventArgs<T>> Changed;

        public int Count => list.Count;

        public T this[int index]
        {
            get => list[index];
            set
            {
                var oldValue = list[index];
                list[index] = value;
                Changed?.Invoke(this, new ListChangedEventArgs<T>(value, ChangeType.Update, index, oldValue));
            }
        }

        public void Add(T item)
        {
            list.Add(item);
            Changed?.Invoke(this, new ListChangedEventArgs<T>(item, ChangeType.Add, list.Count - 1));
        }

        public bool Remove(T item)
        {
            var index = list.IndexOf(item);
            if (index >= 0)
            {
                list.RemoveAt(index);
                Changed?.Invoke(this, new ListChangedEventArgs<T>(item, ChangeType.Remove, index));
                return true;
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= 0)
            {
                var item = list[index];
                list.RemoveAt(index);
                Changed?.Invoke(this, new ListChangedEventArgs<T>(item, ChangeType.Remove, index));
                return true;
            }
            return false;
        }

        public void Clear()
        {
            list.Clear();
            Changed?.Invoke(this, new ListChangedEventArgs<T>(default, ChangeType.Clear, -1));
        }

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
