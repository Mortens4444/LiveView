SELECT d.*, c.EncryptedUsername, c.EncryptedPassword FROM DatabaseServers AS d
LEFT JOIN Credentials AS c ON d.DatabaseServerCredentialsId = c.Id
WHERE d.Id = @Id;