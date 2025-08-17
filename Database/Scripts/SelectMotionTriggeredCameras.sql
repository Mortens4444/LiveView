SELECT
    c.Id,
    VideoServerId,
    FullscreenMode,
    StreamId,
    Guid,
    CameraName,
    c.IpAddress,
    MotionTrigger,
    MotionTriggerMinimumLength,
    PartnerCameraId,
    RecorderIndex,
    StreamUrl,
    Priority,
    cc.EncryptedUsername AS CameraUsername,
    cc.EncryptedPassword AS CameraPassword,
    vc.EncryptedUsername AS ServerEncryptedUsername,
    vc.EncryptedPassword AS ServerEncryptedPassword
FROM
    Cameras AS c
LEFT JOIN
    VideoServers AS s ON c.VideoServerId = s.Id
LEFT JOIN
    Credentials AS vc ON s.VideoServerCredentialsId = vc.Id
LEFT JOIN
    Credentials AS cc ON c.CameraCredentialsId = cc.Id;
