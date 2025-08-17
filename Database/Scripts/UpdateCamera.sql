UPDATE Cameras SET 
    RecorderIndex = @RecorderIndex,
    CameraName = @CameraName,
    FullscreenMode = @FullscreenMode,
    Guid = @Guid,
    StreamUrl = @StreamUrl,
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
    EncryptedUsername = @EncryptedUsername,
    EncryptedPassword = @EncryptedPassword
WHERE Id = @CameraCredentialsId;
