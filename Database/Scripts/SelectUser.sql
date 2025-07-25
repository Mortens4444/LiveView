SELECT u.*, c.EncryptedUsername, c.EncryptedPassword FROM Users AS u
LEFT JOIN Credentials AS c ON u.LoginCredentialsId = c.Id
WHERE c.Id = @Id