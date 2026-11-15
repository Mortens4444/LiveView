using Mtf.Database.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Database.Repositories.InMemory;

/// <summary>
/// Generic in-memory replacement of a SQL table repository. Used when no database is available.
/// Rows are copied on the way in and out, so it behaves like a real database
/// (changes become visible only after Insert/Update).
/// </summary>
public class InMemoryRepository<TModel, TKey> : IRepository<TModel, TKey>
    where TModel : class, IHasIdentifier<TKey>
{
    /// <summary>When true the repository generates the Id (like IDENTITY), otherwise the caller supplies it.</summary>
    protected virtual bool UsesIdentity => true;

    protected static object SyncRoot => InMemoryStore.SyncRoot;

    /// <summary>Stored rows. Callers must hold <see cref="SyncRoot"/>.</summary>
    protected static List<TModel> Items => InMemoryStore<TModel>.Items;

    public virtual TModel Select(TKey id)
    {
        lock (SyncRoot)
        {
            var item = Find(id);
            return item == null ? null : Hydrate(InMemoryStore<TModel>.Clone(item));
        }
    }

    public virtual ReadOnlyCollection<TModel> SelectAll()
    {
        lock (SyncRoot)
        {
            return Copy(Order(Items));
        }
    }

    public virtual ReadOnlyCollection<TModel> SelectWhere(object param)
    {
        lock (SyncRoot)
        {
            return Copy(Order(Items.Where(item => MatchesParam(item, param))));
        }
    }

    public virtual void Insert(TModel model)
    {
        InsertInternal(model);
    }

    public virtual T InsertAndReturnId<T>(TModel model) where T : struct
    {
        var id = InsertInternal(model);
        return (T)Convert.ChangeType(id, typeof(T), CultureInfo.InvariantCulture);
    }

    public virtual void Update(TModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        lock (SyncRoot)
        {
            var index = Items.FindIndex(item => SameRow(item, model));
            if (index >= 0)
            {
                Items[index] = InMemoryStore<TModel>.Clone(model);
            }
        }
    }

    public virtual void Delete(TKey id)
    {
        lock (SyncRoot)
        {
            RemoveRange(Items.Where(item => KeyEquals(item, id)).ToList());
        }
    }

    public virtual void DeleteWhere(object param)
    {
        lock (SyncRoot)
        {
            RemoveRange(Items.Where(item => MatchesParam(item, param)).ToList());
        }
    }

    /// <summary>Fills computed (joined) fields on a copy that is about to be returned.</summary>
    protected virtual TModel Hydrate(TModel model)
    {
        return model;
    }

    /// <summary>Gives a subclass the chance to set generated columns on a row that is about to be stored.</summary>
    protected virtual void OnInserting(TModel item)
    {
    }

    /// <summary>Emulates ON DELETE CASCADE / SET NULL. Called after the row was removed.</summary>
    protected virtual void OnDeleted(TModel item)
    {
    }

    protected virtual IEnumerable<TModel> Order(IEnumerable<TModel> items)
    {
        return items;
    }

    protected virtual bool KeyEquals(TModel item, TKey id)
    {
        return EqualityComparer<TKey>.Default.Equals(item.Id, id);
    }

    /// <summary>Primary key comparison of two rows (override for composite keys).</summary>
    protected virtual bool SameRow(TModel left, TModel right)
    {
        return KeyEquals(left, right.Id);
    }

    /// <summary>
    /// Default SelectWhere/DeleteWhere semantic: every property of the anonymous parameter object
    /// has to be equal to the same-named property of the row. A property the row does not have never matches
    /// (a real database would reject such a query), so DeleteWhere can not wipe a table by accident.
    /// </summary>
    protected virtual bool MatchesParam(TModel item, object param)
    {
        if (param == null)
        {
            return true;
        }

        foreach (var paramProperty in param.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            var modelProperty = typeof(TModel).GetProperty(paramProperty.Name, BindingFlags.Instance | BindingFlags.Public);
            if (modelProperty == null)
            {
                return false;
            }

            if (!ValuesEqual(paramProperty.GetValue(param), modelProperty.GetValue(item)))
            {
                return false;
            }
        }

        return true;
    }

    protected static bool TryGetParam(object param, string name, out object value)
    {
        value = null;
        var property = param?.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
        if (property == null)
        {
            return false;
        }

        value = property.GetValue(param);
        return true;
    }

    protected static bool ValuesEqual(object left, object right)
    {
        if (left == null || right == null)
        {
            return left == null && right == null;
        }

        if (left is string leftText && right is string rightText)
        {
            return String.Equals(leftText, rightText, StringComparison.OrdinalIgnoreCase);
        }

        if (IsNumeric(left) && IsNumeric(right))
        {
            return ToDecimal(left) == ToDecimal(right);
        }

        return left.Equals(right);
    }

    protected static bool IsNumeric(object value)
    {
        return value is Enum || value is sbyte || value is byte || value is short || value is ushort
            || value is int || value is uint || value is long || value is ulong
            || value is float || value is double || value is decimal;
    }

    protected static decimal ToDecimal(object value)
    {
        if (value is Enum)
        {
            value = Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), CultureInfo.InvariantCulture);
        }

        return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
    }

    /// <summary>Reads the items of a "WHERE x IN @param" style parameter as numbers (nulls are skipped).</summary>
    protected static HashSet<decimal> ToNumberSet(object values)
    {
        var result = new HashSet<decimal>();
        if (values is IEnumerable enumerable && !(values is string))
        {
            foreach (var value in enumerable)
            {
                if (value != null)
                {
                    result.Add(ToDecimal(value));
                }
            }
        }

        return result;
    }

    private TKey InsertInternal(TModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        lock (SyncRoot)
        {
            var item = InMemoryStore<TModel>.Clone(model);
            if (UsesIdentity)
            {
                item.Id = NextIdentity();
            }
            else if (Items.Any(existing => SameRow(existing, item)))
            {
                throw new InvalidOperationException($"Violation of PRIMARY KEY constraint. Cannot insert duplicate key '{item.Id}' in '{typeof(TModel).Name}'.");
            }

            OnInserting(item);
            Items.Add(item);
            return item.Id;
        }
    }

    private void RemoveRange(List<TModel> toRemove)
    {
        foreach (var item in toRemove)
        {
            Items.Remove(item);
            OnDeleted(item);
        }
    }

    private TModel Find(TKey id)
    {
        return Items.FirstOrDefault(item => KeyEquals(item, id));
    }

    /// <summary>Copies rows for returning them to the caller. Callers must hold <see cref="SyncRoot"/>.</summary>
    protected ReadOnlyCollection<TModel> Copy(IEnumerable<TModel> source)
    {
        return new ReadOnlyCollection<TModel>(source.Select(item => Hydrate(InMemoryStore<TModel>.Clone(item))).ToList());
    }

    private static TKey NextIdentity()
    {
        var next = ++InMemoryStore<TModel>.LastIdentity;
        if (typeof(TKey) == typeof(int))
        {
            return (TKey)(object)checked((int)next);
        }

        if (typeof(TKey) == typeof(long))
        {
            return (TKey)(object)next;
        }

        throw new NotSupportedException($"Identity generation is not supported for key type '{typeof(TKey).Name}'.");
    }
}
