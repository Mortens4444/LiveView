SELECT 
    c.*,
    s.Hostname AS ServerDisplayName,
    vc.Username AS ServerUsername,
    vc.EncryptedPassword AS ServerPassword,
    cc.Username AS Username,
    cc.EncryptedPassword AS Password,
    s.Id AS ServerId
FROM 
    Cameras AS c
LEFT JOIN
    Servers AS s ON c.ServerId = s.Id
LEFT JOIN
    Credentials AS vc ON s.VideoServerCredentialsId = vc.Id
LEFT JOIN
    Credentials AS cc ON c.CameraCredentialsId = cc.Id;