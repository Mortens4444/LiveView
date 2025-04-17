using LiveView.Core.CustomEventArgs;
using LiveView.Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LiveView.Core
{
    public class ObservableDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IReadOnlyDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        public event EventHandler<DictionaryChangedEventArgs<TKey, TValue>> Changed;

        public IReadOnlyDictionary<TKey, TValue> Items => dictionary;

        public IEnumerable<TKey> Keys => dictionary.Keys;

        public IEnumerable<TValue> Values => dictionary.Values;

        public int Count => dictionary.Count;

        public void Add(TKey key, TValue value)
        {
            dictionary.Add(key, value);
            Changed?.Invoke(this, new DictionaryChangedEventArgs<TKey, TValue>(key, value, ChangeType.Add));
        }

        public bool Remove(TKey key)
        {
            if (dictionary.TryGetValue(key, out var value) && dictionary.Remove(key))
            {
                Changed?.Invoke(this, new DictionaryChangedEventArgs<TKey, TValue>(key, value, ChangeType.Remove));
                return true;
            }
            return false;
        }

        public void Clear()
        {
            dictionary.Clear();
            Changed?.Invoke(this, new DictionaryChangedEventArgs<TKey, TValue>(default, default, ChangeType.Clear));
        }

        public bool TryGetValue(TKey key, out TValue value) => dictionary.TryGetValue(key, out value);

        public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);

        public TValue this[TKey key]
        {
            get => dictionary[key];
            set
            {
                var changeType = dictionary.ContainsKey(key) ? ChangeType.Update : ChangeType.Add;
                dictionary[key] = value;
                Changed?.Invoke(this, new DictionaryChangedEventArgs<TKey, TValue>(key, value, changeType));
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => dictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
