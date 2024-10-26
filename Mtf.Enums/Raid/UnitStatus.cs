namespace Mtf.Enums.Raid
{
    public enum UnitStatus : byte
    {
        Ok,
        Recovery,
        Inoperable,
        Unknown,
        Degraded,
        Initializing,
        Init_paused,
        Verifying,
        Verify_paused,
        Rebuilding,
        Rebuild_paused,
        Migrating,
        Migrate_paused
    }
}
