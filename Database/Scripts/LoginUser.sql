SELECT u.*, c.Username FROM Users AS u
JOIN Credentials AS c ON u.LoginCredentialsId = c.Id
WHERE c.Username = @Username AND c.EncryptedPassword = @EncryptedPassword;
