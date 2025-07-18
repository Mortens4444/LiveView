SELECT u.Id FROM Users AS u
INNER JOIN Credentials AS c ON u.LoginCredentialsId = c.Id
WHERE c.Username = @Username AND c.EncryptedPassword = @Password;
