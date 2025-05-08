namespace Mtf.Web.Interfaces
{
    public interface IConverter<TModel, TDto>
    {
        TDto ToDto(TModel model);

        TModel ToModel(TDto dto);
    }
}
