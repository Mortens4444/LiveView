namespace Mtf.Enums.Sql
{
    public enum ConstraintAction : byte
    {
        NO_ACTION,
        ON_DELETE_CASCADE,
        ON_UPDATE_CASCADE,
        ON_DELETE_CASCADE_AND_ON_UPDATE_CASCADE
    }
}
