using Database.Interfaces;
using Database.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Database.Repositories.InMemory;

public sealed class InMemoryGridRepository : InMemoryRepository<Grid, int>, IGridRepository
{
    protected override void OnDeleted(Grid grid)
    {
        new InMemoryGridCameraRepository().DeleteWhere(new { GridId = grid.Id });
        new InMemorySequenceGridsRepository().DeleteWhere(new { GridId = grid.Id });
    }
}

public sealed class InMemoryGridCameraRepository : InMemoryRepository<GridCamera, int>, IGridCameraRepository
{
    public void DeleteCamerasOfGrid(int id)
    {
        DeleteWhere(new { GridId = id });
    }

    public ReadOnlyCollection<GridCamera> GetCombinedGridCameras(int gridId)
    {
        lock (SyncRoot)
        {
            return Copy(Items.Where(gridCamera => gridCamera.GridId == gridId && gridCamera.EndRow.HasValue));
        }
    }
}

public sealed class InMemorySequenceRepository : InMemoryRepository<Sequence, int>, ISequenceRepository
{
    /// <summary>Counts the cameras of every grid of the sequence (a grid used twice is counted twice, like the SQL join).</summary>
    public long SelectCameraCount(long sequenceId)
    {
        lock (SyncRoot)
        {
            return InMemoryStore<SequenceGrid>.Items
                .Where(sequenceGrid => sequenceGrid.SequenceId == sequenceId)
                .Sum(sequenceGrid => (long)InMemoryStore<GridCamera>.Items.Count(gridCamera => gridCamera.GridId == sequenceGrid.GridId));
        }
    }

    protected override void OnDeleted(Sequence sequence)
    {
        new InMemorySequenceGridsRepository().DeleteWhere(new { SequenceId = sequence.Id });
    }
}

public sealed class InMemorySequenceGridsRepository : InMemoryRepository<SequenceGrid, int>, ISequenceGridsRepository
{
    protected override IEnumerable<SequenceGrid> Order(IEnumerable<SequenceGrid> items)
    {
        return items.OrderBy(sequenceGrid => sequenceGrid.Number);
    }
}
