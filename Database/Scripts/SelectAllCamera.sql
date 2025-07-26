SELECT 
    c.*,
    s.Hostname AS ServerDisplayName,
    vc.EncryptedUsername AS ServerEncryptedUsername,
    vc.EncryptedPassword AS ServerEncryptedPassword,
    cc.EncryptedUsername,
    cc.EncryptedPassword
FROM 
    Cameras AS c
LEFT JOIN
    VideoServers AS s ON c.VideoServerId = s.Id
LEFT JOIN
    Credentials AS vc ON s.VideoServerCredentialsId = vc.Id
LEFT JOIN
    Credentials AS cc ON c.CameraCredentialsId = cc.Id;