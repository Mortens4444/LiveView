using Microsoft.Extensions.Logging;
using Mtf.Database.Interfaces;
using Mtf.Extensions.Interfaces;
using Mtf.Web.Interfaces;

namespace LiveView.WebApi.WebAPI
{
    public abstract class ApiControllerBaseWithLongModelId<TDto, TModel, TRepository, TConverter> : ApiControllerBase<TDto, TModel, long, TRepository, TConverter>
        where TDto : IHaveIdWithSetter<long>
        where TModel : IHaveId<long>
        where TRepository : IRepository<TModel, long>
        where TConverter : IConverter<TModel, TDto>
    {
        protected ApiControllerBaseWithLongModelId(ILogger logger, TRepository repository, TConverter converter)
            : base(logger, repository, converter)
        {
        }

        protected override TModel Select(long id) => Repository.Select(id);
    }
}
