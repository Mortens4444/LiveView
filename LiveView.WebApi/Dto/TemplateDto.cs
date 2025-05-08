using Mtf.Database.Interfaces;

namespace LiveView.WebApi.Dto
{
    /// <summary>
    /// Data Transfer Object for the Template entity.
    /// Used to transfer data between the API and clients.
    /// </summary>
    public record TemplateDto : IHaveIdWithSetter<long>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the template.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the template.
        /// </summary>
        public string? TemplateName { get; set; }

        /// <summary>
        /// Provides a string representation of the TemplateDto, primarily the TemplateName.
        /// </summary>
        /// <returns>The name of the template or an empty string if null.</returns>
        public override string ToString()
        {
            return TemplateName ?? String.Empty;
        }
    }
}
