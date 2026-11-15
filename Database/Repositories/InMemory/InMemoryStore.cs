using System;
using System.Collections.Generic;
using System.Reflection;

namespace Database.Repositories.InMemory;

/// <summary>
/// Process-wide lock shared by every in-memory table. A single lock keeps cascading
/// operations (which touch several tables) free of lock-ordering problems.
/// </summary>
internal static class InMemoryStore
{
    internal static readonly object SyncRoot = new object();

    private static readonly object ResetActionsLock = new object();

    private static readonly List<Action> ResetActions = new List<Action>();

    internal static void RegisterReset(Action reset)
    {
        lock (ResetActionsLock)
        {
            ResetActions.Add(reset);
        }
    }

    /// <summary>Empties every in-memory table (used by tests).</summary>
    internal static void Reset()
    {
        lock (SyncRoot)
        {
            Action[] resetActions;
            lock (ResetActionsLock)
            {
                resetActions = ResetActions.ToArray();
            }

            foreach (var reset in resetActions)
            {
                reset();
            }
        }
    }
}

/// <summary>
/// Backing list of one in-memory "table". All access must happen inside <c>lock (InMemoryStore.SyncRoot)</c>.
/// </summary>
internal static class InMemoryStore<TModel> where TModel : class
{
    private static readonly MethodInfo MemberwiseCloneMethod = typeof(object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);

    internal static readonly List<TModel> Items = new List<TModel>();

    internal static long LastIdentity;

    static InMemoryStore()
    {
        InMemoryStore.RegisterReset(() =>
        {
            Items.Clear();
            LastIdentity = 0;
        });
    }

    /// <summary>Shallow copy, so callers can never mutate stored rows without calling Update (same as a real database).</summary>
    internal static TModel Clone(TModel model)
    {
        return (TModel)MemberwiseCloneMethod.Invoke(model, null);
    }
}
