SELECT 
    c.Id, 
    FullscreenMode, 
    StreamId, 
    cc.Username AS CameraUsername, 
    cc.EncryptedPassword AS CameraPassword,
    Guid, 
    CameraName, 
    c.IpAddress, 
    vc.Username AS ServerUsername, 
    vc.EncryptedPassword AS ServerPassword, 
    s.Id AS ServerId, 
    MotionTrigger, 
    MotionTriggerMinimumLength, 
    PartnerCameraId, 
    RecorderIndex, 
    HttpStreamUrl, 
    Priority
FROM 
    Cameras AS c
LEFT JOIN 
    Servers AS s ON c.ServerId = s.Id
LEFT JOIN 
    Credentials AS vc ON s.VideoServerCredentialsId = vc.Id
LEFT JOIN 
    Credentials AS cc ON c.CameraCredentialsId = cc.Id;
