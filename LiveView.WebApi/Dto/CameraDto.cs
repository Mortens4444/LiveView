using Database.Enums;
using Mtf.Database.Interfaces;

namespace LiveView.WebApi.Dto
{
    /// <summary>
    /// Data Transfer Object for the Camera entity.
    /// Used to transfer camera data between the API and clients.
    /// </summary>
    public record CameraDto : IHaveIdWithSetter<long>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the camera.
        /// Corresponds to the database Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the optional foreign key reference to a partner camera's Id.
        /// </summary>
        public long? PartnerCameraId { get; set; }

        /// <summary>
        /// Gets or sets the globally unique identifier (GUID) for the camera.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the name of the camera.
        /// </summary>
        public string? CameraName { get; set; }

        /// <summary>
        /// Gets or sets the IP address of the camera.
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the fullscreen mode setting for the camera.
        /// Assumes CameraMode is an enum or type defined elsewhere.
        /// </summary>
        public CameraMode FullscreenMode { get; set; }

        /// <summary>
        /// Gets or sets the optional stream identifier.
        /// </summary>
        public int? StreamId { get; set; }

        /// <summary>
        /// Gets or sets the username for accessing the camera stream.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the password for accessing the camera stream.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the username for accessing the server hosting the camera.
        /// </summary>
        public string? ServerUsername { get; set; }

        /// <summary>
        /// Gets or sets the display name for accessing the server hosting the camera.
        /// </summary>
        public string? ServerDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the password for accessing the server hosting the camera.
        /// </summary>
        public string? ServerPassword { get; set; }

        /// <summary>
        /// Gets or sets the HTTP stream URL for the camera.
        /// </summary>
        public string? HttpStreamUrl { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating if the camera is currently active or actual.
        /// </summary>
        public bool Actual { get; set; }

        /// <summary>
        /// Gets or sets the foreign key reference to the Server entity's Id.
        /// Indicates which server hosts this camera.
        /// </summary>
        public long ServerId { get; set; }

        /// <summary>
        /// Gets or sets the optional identifier for motion triggering.
        /// </summary>
        public long? MotionTrigger { get; set; }

        /// <summary>
        /// Gets or sets the optional minimum length for motion triggering.
        /// </summary>
        public long? MotionTriggerMinimumLength { get; set; }

        /// <summary>
        /// Gets or sets the priority of the camera.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the recorder index for the camera.
        /// </summary>
        public int RecorderIndex { get; set; }

        /// <summary>
        /// Gets or sets the optional CameraId (potentially for external systems).
        /// Note: There's also an 'Id' property. Clarification might be needed on usage.
        /// </summary>
        public int? CameraId { get; set; }

        /// <summary>
        /// Gets or sets the optional foreign key reference to a VideoSource entity's Id.
        /// </summary>
        public long? VideoSourceId { get; set; }

        /// <summary>
        /// Provides a string representation of the CameraDto, primarily the CameraName.
        /// </summary>
        /// <returns>The name of the camera or an empty string if null.</returns>
        public override string ToString()
        {
            return CameraName ?? String.Empty;
        }
    }
}
