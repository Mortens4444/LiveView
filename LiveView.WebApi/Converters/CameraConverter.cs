using LiveView.WebApi.Dto;
using Database.Models;

namespace LiveView.WebApi.Converters
{
    /// <summary>
    /// Converts between Database.Models.Camera and LiveView.WebApi.Dto.CameraDto.
    /// Handles the mapping of properties between the database model and the DTO.
    /// </summary>
    public class CameraConverter
    {
        /// <summary>
        /// Converts a Database.Models.Camera object to a CameraDto object.
        /// </summary>
        /// <param name="camera">The source Camera model from the database.</param>
        /// <returns>The converted CameraDto, or null if the source model is null.</returns>
        public CameraDto? ToDto(Camera camera)
        {
            if (camera == null)
            {
                return null;
            }

            return new CameraDto
            {
                Id = camera.Id,
                PartnerCameraId = camera.PartnerCameraId,
                Guid = Guid.Parse(camera.Guid),
                CameraName = camera.CameraName,
                IpAddress = camera.IpAddress,
                FullscreenMode = camera.FullscreenMode,
                StreamId = camera.StreamId,
                Username = camera.Username,
                Password = camera.Password,
                ServerUsername = camera.ServerUsername,
                ServerPassword = camera.ServerPassword,
                HttpStreamUrl = camera.HttpStreamUrl,
                Actual = camera.Actual,
                ServerId = camera.ServerId,
                MotionTrigger = camera.MotionTrigger,
                MotionTriggerMinimumLength = camera.MotionTriggerMinimumLength,
                Priority = camera.Priority,
                RecorderIndex = camera.RecorderIndex,
                CameraId = camera.CameraId,
                VideoSourceId = camera.VideoSourceId
            };
        }

        /// <summary>
        /// Converts a CameraDto object to a Database.Models.Camera object.
        /// </summary>
        /// <param name="cameraDto">The source CameraDto.</param>
        /// <returns>The converted Database.Models.Camera, or null if the source DTO is null.</returns>
        public Camera? ToModel(CameraDto cameraDto)
        {
            if (cameraDto == null)
            {
                return null;
            }

            return new Camera
            {
                Id = cameraDto.Id,
                PartnerCameraId = cameraDto.PartnerCameraId,
                Guid = cameraDto.Guid.ToString(),
                CameraName = cameraDto.CameraName,
                IpAddress = cameraDto.IpAddress,
                FullscreenMode = cameraDto.FullscreenMode,
                StreamId = cameraDto.StreamId,
                Username = cameraDto.Username,
                Password = cameraDto.Password,
                ServerUsername = cameraDto.ServerUsername,
                ServerPassword = cameraDto.ServerPassword,
                HttpStreamUrl = cameraDto.HttpStreamUrl,
                Actual = cameraDto.Actual,
                ServerId = cameraDto.ServerId,
                MotionTrigger = cameraDto.MotionTrigger,
                MotionTriggerMinimumLength = cameraDto.MotionTriggerMinimumLength,
                Priority = cameraDto.Priority,
                RecorderIndex = cameraDto.RecorderIndex,
                CameraId = cameraDto.CameraId,
                VideoSourceId = cameraDto.VideoSourceId
            };
        }
    }
}
