using Database.Models;
using LiveView.WebApi.Dto;
using LiveView.WebApi.Interfaces;

namespace LiveView.WebApi.Converters
{
    public class TemplateConverter : IConverter<Template, TemplateDto>
    {
        /// <summary>
        /// Converts a Database.Models.Template object to a TemplateDto object.
        /// </summary>
        /// <param name="model">The source Template model.</param>
        /// <returns>The converted TemplateDto, or null if the source is null.</returns>
        public TemplateDto? ToDto(Template? model)
        {
            if (model == null)
            {
                return null;
            }

            return new TemplateDto
            {
                Id = model.Id,
                TemplateName = model.TemplateName
            };
        }

        /// <summary>
        /// Converts a TemplateDto object to a Database.Models.Template object.
        /// </summary>
        /// <param name="dto">The source TemplateDto.</param>
        /// <returns>The converted Database.Models.Template, or null if the source DTO is null.</returns>
        public Template? ToModel(TemplateDto? dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Template
            {
                Id = dto.Id,
                TemplateName = dto.TemplateName
            };
        }
    }
}
