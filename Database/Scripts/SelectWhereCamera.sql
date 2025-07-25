SELECT c.*, cc.EncryptedUsername, cc.EncryptedPassword,
    vc.EncryptedUsername AS ServerEncryptedUsername,
    vc.EncryptedPassword AS ServerEncryptedPassword,
    s.Id AS ServerId
FROM
    Cameras AS c
LEFT JOIN
    Servers AS s ON c.ServerId = s.Id
LEFT JOIN
    Credentials AS vc ON s.VideoServerCredentialsId = vc.Id
LEFT JOIN
    Credentials AS cc ON c.CameraCredentialsId = cc.Id
WHERE
    c.ServerId = @ServerId;
