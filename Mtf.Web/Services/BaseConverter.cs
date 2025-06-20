using Mtf.Web.Interfaces;

namespace LiveView.Web.Services
{
    /// <summary>
    /// Provides a base implementation for converting between a model and its corresponding DTO.
    /// Performs shallow copy of matching properties by name and type.
    /// </summary>
    /// <typeparam name="TModel">The source model type.</typeparam>
    /// <typeparam name="TDto">The target DTO type.</typeparam>
    public abstract class BaseConverter<TModel, TDto> : IConverter<TModel, TDto>
        where TModel : class, new()
        where TDto : class, new()
    {
        /// <summary>
        /// Converts a model to its corresponding DTO by copying matching properties.
        /// </summary>
        /// <param name="model">The source model instance.</param>
        /// <returns>A new DTO instance with copied properties, or null if the source is null.</returns>
        public virtual TDto ToDto(TModel model)
        {
            if (model == null)
            {
                return null;
            }

            var dto = new TDto();
            PropertyCopier.CopyMatchingProperties(model, dto);
            return dto;
        }

        /// <summary>
        /// Converts a DTO to its corresponding model by copying matching properties.
        /// </summary>
        /// <param name="dto">The source DTO instance.</param>
        /// <returns>A new model instance with copied properties, or null if the source is null.</returns>
        public virtual TModel ToModel(TDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            var model = new TModel();
            PropertyCopier.CopyMatchingProperties(dto, model);
            return model;
        }
    }
}
