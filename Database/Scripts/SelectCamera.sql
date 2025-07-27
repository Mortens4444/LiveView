SELECT c.*, cc.EncryptedUsername, cc.EncryptedPassword FROM Cameras AS c
LEFT JOIN
    Credentials AS cc ON c.CameraCredentialsId = cc.Id
WHERE c.Id = @Id