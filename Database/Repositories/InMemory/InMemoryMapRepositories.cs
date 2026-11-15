using Database.Interfaces;
using Database.Models;
using Mtf.Database.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Database.Repositories.InMemory;

public sealed class InMemoryMapRepository : InMemoryRepository<Map, int>, IMapRepository
{
    /// <summary>Same as DeleteMap.sql: action objects that were only on this map are deleted with it.</summary>
    protected override void OnDeleted(Map map)
    {
        var actionObjectIds = InMemoryStore<MapActionObject>.Items
            .Where(mapActionObject => mapActionObject.MapId == map.Id)
            .Select(mapActionObject => mapActionObject.ActionObjectId)
            .ToList();

        new InMemoryMapActionObjectRepository().DeleteWhere(new { MapId = map.Id });

        var actionObjectRepository = new InMemoryActionObjectRepository();
        foreach (var actionObjectId in actionObjectIds.Distinct())
        {
            if (!InMemoryStore<MapActionObject>.Items.Any(mapActionObject => mapActionObject.ActionObjectId == actionObjectId))
            {
                actionObjectRepository.Delete(actionObjectId);
            }
        }
    }
}

public sealed class InMemoryActionObjectRepository : InMemoryRepository<ActionObject, int>, IActionObjectRepository
{
    /// <summary>Supports <c>SelectWhere(new { map.Id })</c> which returns the action objects placed on the map.</summary>
    public override ReadOnlyCollection<ActionObject> SelectWhere(object param)
    {
        if (!TryGetParam(param, "Id", out var mapId))
        {
            return base.SelectWhere(param);
        }

        lock (SyncRoot)
        {
            var actionObjectIds = InMemoryStore<MapActionObject>.Items
                .Where(mapActionObject => ValuesEqual(mapActionObject.MapId, mapId))
                .Select(mapActionObject => mapActionObject.ActionObjectId)
                .ToList();
            return Copy(Items.Where(actionObject => actionObjectIds.Contains(actionObject.Id)));
        }
    }

    protected override void OnDeleted(ActionObject actionObject)
    {
        new InMemoryMapActionObjectRepository().DeleteWhere(new { ActionObjectId = actionObject.Id });
    }
}

public sealed class InMemoryMapActionObjectRepository : InMemoryRepository<MapActionObject, int>, IMapActionObjectRepository
{
    /// <summary>Supports <c>SelectWhere(new { map.Id })</c> which returns the links of the map.</summary>
    public override ReadOnlyCollection<MapActionObject> SelectWhere(object param)
    {
        if (!TryGetParam(param, "Id", out var mapId))
        {
            return base.SelectWhere(param);
        }

        lock (SyncRoot)
        {
            return Copy(Items.Where(mapActionObject => ValuesEqual(mapActionObject.MapId, mapId)));
        }
    }

    /// <summary>Supports <c>DeleteWhere(new { mapObject.Id })</c> which removes an action object from every map.</summary>
    public override void DeleteWhere(object param)
    {
        if (!TryGetParam(param, "Id", out var actionObjectId))
        {
            base.DeleteWhere(param);
            return;
        }

        base.DeleteWhere(new { ActionObjectId = actionObjectId });
    }

    public MapActionObject SelectByKey(MapActionObject key)
    {
        lock (SyncRoot)
        {
            var item = Items.FirstOrDefault(existing => IsSameLink(existing, key));
            return item == null ? null : Copy(new[] { item }).First();
        }
    }

    public void DeleteByKey(MapActionObject key)
    {
        lock (SyncRoot)
        {
            Items.RemoveAll(existing => IsSameLink(existing, key));
        }
    }

    IEnumerable<MapActionObject> IRepositoryWithCompositeKey<MapActionObject, MapActionObject>.SelectAll()
    {
        return SelectAll();
    }

    private static bool IsSameLink(MapActionObject left, MapActionObject right)
    {
        return left.MapId == right.MapId && left.ActionObjectId == right.ActionObjectId;
    }
}
