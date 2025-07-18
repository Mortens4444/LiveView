SELECT c.*, cc.Username, cc.EncryptedPassword AS Password FROM Cameras AS c
LEFT JOIN
    Credentials AS cc ON c.CameraCredentialsId = cc.Id
WHERE Id = @Id