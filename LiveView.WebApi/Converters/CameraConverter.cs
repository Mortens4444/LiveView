using Database.Models;
using LiveView.Web.Services;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;

namespace LiveView.WebApi.Converters
{
    /// <summary>
    /// Converts between Database.Models.Camera and LiveView.WebApi.Dto.CameraDto.
    /// Handles the mapping of properties between the database model and the DTO.
    /// </summary>
    public class CameraConverter : IConverter<Camera, CameraDto>
    {
        /// <summary>
        /// Converts a Database.Models.Camera object to a CameraDto object.
        /// </summary>
        /// <param name="model">The source Camera model from the database.</param>
        /// <returns>The converted CameraDto, or null if the source model is null.</returns>
        public CameraDto? ToDto(Camera? model)
        {
            if (model == null)
            {
                return null;
            }

            var dto = new CameraDto();
            PropertyCopier.CopyMatchingProperties(model, dto);
            dto.Guid = Guid.Parse(model.Guid);
            return dto;
        }

        /// <summary>
        /// Converts a CameraDto object to a Database.Models.Camera object.
        /// </summary>
        /// <param name="dto">The source CameraDto.</param>
        /// <returns>The converted Database.Models.Camera, or null if the source DTO is null.</returns>
        public Camera? ToModel(CameraDto? dto)
        {
            if (dto == null)
            {
                return null;
            }

            var model = new Camera();
            PropertyCopier.CopyMatchingProperties(dto, model);
            model.Guid = dto.Guid.ToString();
            return model;
        }
    }
}
