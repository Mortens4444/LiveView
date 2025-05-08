using Database.Models;
using LiveView.WebApi.Dto;
using LiveView.WebApi.Interfaces;

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

            return new CameraDto
            {
                Id = model.Id,
                PartnerCameraId = model.PartnerCameraId,
                Guid = Guid.Parse(model.Guid),
                CameraName = model.CameraName,
                IpAddress = model.IpAddress,
                FullscreenMode = model.FullscreenMode,
                StreamId = model.StreamId,
                Username = model.Username,
                Password = model.Password,
                ServerUsername = model.ServerUsername,
                ServerPassword = model.ServerPassword,
                HttpStreamUrl = model.HttpStreamUrl,
                Actual = model.Actual,
                ServerId = model.ServerId,
                MotionTrigger = model.MotionTrigger,
                MotionTriggerMinimumLength = model.MotionTriggerMinimumLength,
                Priority = model.Priority,
                RecorderIndex = model.RecorderIndex,
                CameraId = model.CameraId,
                VideoSourceId = model.VideoSourceId
            };
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

            return new Camera
            {
                Id = dto.Id,
                PartnerCameraId = dto.PartnerCameraId,
                Guid = dto.Guid.ToString(),
                CameraName = dto.CameraName,
                IpAddress = dto.IpAddress,
                FullscreenMode = dto.FullscreenMode,
                StreamId = dto.StreamId,
                Username = dto.Username,
                Password = dto.Password,
                ServerUsername = dto.ServerUsername,
                ServerPassword = dto.ServerPassword,
                HttpStreamUrl = dto.HttpStreamUrl,
                Actual = dto.Actual,
                ServerId = dto.ServerId,
                MotionTrigger = dto.MotionTrigger,
                MotionTriggerMinimumLength = dto.MotionTriggerMinimumLength,
                Priority = dto.Priority,
                RecorderIndex = dto.RecorderIndex,
                CameraId = dto.CameraId,
                VideoSourceId = dto.VideoSourceId
            };
        }
    }
}
