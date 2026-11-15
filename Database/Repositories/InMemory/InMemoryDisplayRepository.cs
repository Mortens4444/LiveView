using Database.Interfaces;
using Database.Models;
using System.Linq;

namespace Database.Repositories.InMemory;

public sealed class InMemoryDisplayRepository : InMemoryRepository<Display, int>, IDisplayRepository
{
    /// <summary>Display ids come from the operating system (see DisplayDto.GetId), not from the table.</summary>
    protected override bool UsesIdentity => false;

    public Display GetFullscreenDisplay()
    {
        lock (SyncRoot)
        {
            var display = Items.FirstOrDefault(existing => existing.Fullscreen);
            return display == null ? null : Copy(new[] { display }).First();
        }
    }

    /// <summary>
    /// InsertDisplay.sql is an upsert: a known display only gets its hardware properties refreshed,
    /// the user's choices (fullscreen display, can show sequence, can show fullscreen) are kept.
    /// </summary>
    public override void Insert(Display model)
    {
        lock (SyncRoot)
        {
            var existing = Items.FirstOrDefault(display => display.Id == model.Id);
            if (existing == null)
            {
                base.Insert(model);
                return;
            }

            existing.SziltechId = model.SziltechId;
            existing.MonitorName = model.MonitorName;
            existing.AdapterName = model.AdapterName;
            existing.X = model.X;
            existing.Y = model.Y;
            existing.Width = model.Width;
            existing.Height = model.Height;
            existing.MaxWidth = model.MaxWidth;
            existing.MaxHeight = model.MaxHeight;
            existing.DeviceName = model.DeviceName;
            existing.IsPrimary = model.IsPrimary;
            existing.Removable = model.Removable;
            existing.AttachedToDesktop = model.AttachedToDesktop;
        }
    }
}
