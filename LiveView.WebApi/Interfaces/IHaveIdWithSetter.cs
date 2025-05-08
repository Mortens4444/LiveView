namespace LiveView.WebApi.Interfaces
{
    public interface IHaveIdWithSetter<IdType>
        where IdType : struct
    {
        IdType Id { get; set; }
    }
}
