UPDATE Cameras SET
    RecorderIndex = @RecorderIndex,
    CameraName = @CameraName,
    FullscreenMode = @FullscreenMode,
    Guid = @Guid,
    HttpStreamUrl = @HttpStreamUrl,
    IpAddress = @IpAddress,
    Priority = @Priority,
    Username = @Username,
    Password = @Password,
    StreamId = @StreamId,
    MotionTrigger = @MotionTrigger,
    MotionTriggerMinimumLength = @MotionTriggerMinimumLength,
    PartnerCameraId = @PartnerCameraId,
    VideoSourceId = @VideoSourceId,
    PermissionCamera = @PermissionCamera
WHERE Id = @Id;