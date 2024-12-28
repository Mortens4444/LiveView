namespace Database.Interfaces
{
    public interface IHaveId<IdType>
        where IdType : struct
    {
        IdType Id { get; }
    }
}
