using LiveView.Core.Enums;
using System;

namespace LiveView.Core.CustomEventArgs
{
    public class DictionaryChangedEventArgs<TKey, TValue> : EventArgs
    {
        public TKey Key { get; }

        public TValue Value { get; }

        public ChangeType ChangeType { get; }

        public DictionaryChangedEventArgs(TKey key, TValue value, ChangeType changeType)
        {
            Key = key;
            Value = value;
            ChangeType = changeType;
        }
    }
}
