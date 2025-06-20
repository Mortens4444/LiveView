using Microsoft.Extensions.Logging;
using Mtf.Database.Interfaces;
using Mtf.Extensions.Interfaces;
using Mtf.Web.Interfaces;

namespace Mtf.Web.WebAPI
{
    public abstract class ApiControllerBaseWithIntModelId<TDto, TModel, TRepository, TConverter> : ApiControllerBase<TDto, TModel, int, TRepository, TConverter>
        where TDto : IHaveIdWithSetter<int>
        where TModel : IHaveId<int>
        where TRepository : IRepository<TModel>
        where TConverter : IConverter<TModel, TDto>
    {
        protected ApiControllerBaseWithIntModelId(ILogger logger, TRepository repository, TConverter converter)
            : base(logger, repository, converter)
        {
        }

        protected override TModel Select(int id)
        {
            return Repository.Select(id);
        }
    }
}
