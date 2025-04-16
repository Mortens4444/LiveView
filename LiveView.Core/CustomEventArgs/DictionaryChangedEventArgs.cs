using LiveView.Core.Enums;
using System;

namespace LiveView.Core.CustomEventArgs
{
    public class DictionaryChangedEventArgs<TKey, TValue> : EventArgs
    {
        public TKey Key { get; }
        public TValue Value { get; }
        public DictionaryChangeType ChangeType { get; }

        public DictionaryChangedEventArgs(TKey key, TValue value, DictionaryChangeType changeType)
        {
            Key = key;
            Value = value;
            ChangeType = changeType;
        }
    }
}
