using LiveView.Core.CustomEventArgs;
using LiveView.Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LiveView.Core
{
    public class ObservableDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IReadOnlyDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        private readonly object syncRoot = new object();

        public event EventHandler<DictionaryChangedEventArgs<TKey, TValue>> Changed;

        public IReadOnlyDictionary<TKey, TValue> Items
        {
            get
            {
                lock (syncRoot)
                {
                    return new Dictionary<TKey, TValue>(dictionary);
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                lock (syncRoot)
                {
                    return dictionary.Keys.ToList();
                }
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                lock (syncRoot)
                {
                    return dictionary.Values.ToList();
                }
            }
        }

        public int Count
        {
            get
            {
                lock (syncRoot)
                {
                    return dictionary.Count;
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            lock (syncRoot)
            {
                dictionary.Add(key, value);
            }
            Changed?.Invoke(this, new DictionaryChangedEventArgs<TKey, TValue>(key, value, ChangeType.Add));
        }

        public bool Remove(TKey key)
        {
            TValue value;
            lock (syncRoot)
            {
                if (!dictionary.TryGetValue(key, out value) || !dictionary.Remove(key))
                {
                    return false;
                }
            }
            Changed?.Invoke(this, new DictionaryChangedEventArgs<TKey, TValue>(key, value, ChangeType.Remove));
            return true;
        }

        public void Clear()
        {
            lock (syncRoot)
            {
                dictionary.Clear();
            }
            Changed?.Invoke(this, new DictionaryChangedEventArgs<TKey, TValue>(default, default, ChangeType.Clear));
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            lock (syncRoot)
            {
                return dictionary.TryGetValue(key, out value);
            }
        }

        public bool ContainsKey(TKey key)
        {
            lock (syncRoot)
            {
                return dictionary.ContainsKey(key);
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                lock (syncRoot)
                {
                    return dictionary[key];
                }
            }
            set
            {
                ChangeType changeType;
                lock (syncRoot)
                {
                    changeType = dictionary.ContainsKey(key) ? ChangeType.Update : ChangeType.Add;
                    dictionary[key] = value;
                }
                Changed?.Invoke(this, new DictionaryChangedEventArgs<TKey, TValue>(key, value, changeType));
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            lock (syncRoot)
            {
                return new List<KeyValuePair<TKey, TValue>>(dictionary).GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
