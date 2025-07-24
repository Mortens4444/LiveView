UPDATE Cameras SET 
    RecorderIndex = @RecorderIndex,
    CameraName = @CameraName,
    FullscreenMode = @FullscreenMode,
    Guid = @Guid,
    HttpStreamUrl = @HttpStreamUrl,
    IpAddress = @IpAddress,
    Priority = @Priority,
    StreamId = @StreamId,
    MotionTrigger = @MotionTrigger,
    MotionTriggerMinimumLength = @MotionTriggerMinimumLength,
    PartnerCameraId = @PartnerCameraId,
    VideoSourceId = @VideoSourceId,
    PermissionCamera = @PermissionCamera
WHERE Id = @Id;

UPDATE Credentials SET 
    Username = @EncryptedUsername,
    EncryptedPassword = @Password
WHERE Id = @CameraCredentialsId;
