using Database.Models;
using LiveView.WebApi.Dto;

namespace LiveView.WebApi.Converters
{
    public class TemplateConverter
    {
        /// <summary>
        /// Converts a Database.Models.Template object to a TemplateDto object.
        /// </summary>
        /// <param name="template">The source Template model.</param>
        /// <returns>The converted TemplateDto, or null if the source is null.</returns>
        public TemplateDto? ToDto(Template template)
        {
            if (template == null)
            {
                return null;
            }

            return new TemplateDto
            {
                Id = template.Id,
                TemplateName = template.TemplateName
            };
        }

        /// <summary>
        /// Converts a TemplateDto object to a Database.Models.Template object.
        /// </summary>
        /// <param name="templateDto">The source TemplateDto.</param>
        /// <returns>The converted Database.Models.Template, or null if the source DTO is null.</returns>
        public Template? ToModel(TemplateDto templateDto)
        {
            if (templateDto == null)
            {
                return null;
            }

            return new Template
            {
                Id = templateDto.Id,
                TemplateName = templateDto.TemplateName
            };
        }
    }
}
