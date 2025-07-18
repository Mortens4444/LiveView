SELECT u.*, c.Username, c.EncryptedPassword FROM Users AS u
LEFT JOIN Credentials AS c ON u.LoginCredentialsId = c.Id
ORDER BY c.Username;
