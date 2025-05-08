namespace LiveView.WebApi.Interfaces
{
    public interface IConverter<TModel, TDto>
    {
        TDto? ToDto(TModel? model);

        TModel? ToModel(TDto? dto);
    }
}
