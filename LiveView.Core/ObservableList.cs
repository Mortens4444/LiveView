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
        private readonly object syncRoot = new object();

        public event EventHandler<ListChangedEventArgs<T>> Changed;

        public int Count
        {
            get
            {
                lock (syncRoot)
                {
                    return list.Count;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                lock (syncRoot)
                {
                    return list[index];
                }
            }
            set
            {
                T oldValue;
                lock (syncRoot)
                {
                    oldValue = list[index];
                    list[index] = value;
                }
                Changed?.Invoke(this, new ListChangedEventArgs<T>(value, ChangeType.Update, index, oldValue));
            }
        }

        public void Add(T item)
        {
            int index;
            lock (syncRoot)
            {
                list.Add(item);
                index = list.Count - 1;
            }
            Changed?.Invoke(this, new ListChangedEventArgs<T>(item, ChangeType.Add, index));
        }

        public bool Remove(T item)
        {
            int index;
            lock (syncRoot)
            {
                index = list.IndexOf(item);
                if (index < 0)
                {
                    return false;
                }
                list.RemoveAt(index);
            }
            Changed?.Invoke(this, new ListChangedEventArgs<T>(item, ChangeType.Remove, index));
            return true;
        }

        public bool RemoveAt(int index)
        {
            T item;
            lock (syncRoot)
            {
                if (index < 0)
                {
                    return false;
                }
                item = list[index];
                list.RemoveAt(index);
            }
            Changed?.Invoke(this, new ListChangedEventArgs<T>(item, ChangeType.Remove, index));
            return true;
        }

        public void Clear()
        {
            lock (syncRoot)
            {
                list.Clear();
            }
            Changed?.Invoke(this, new ListChangedEventArgs<T>(default, ChangeType.Clear, -1));
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (syncRoot)
            {
                return new List<T>(list).GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
