SELECT u.*, c.EncryptedUsername FROM Users AS u
JOIN Credentials AS c ON u.LoginCredentialsId = c.Id
WHERE c.EncryptedUsername = @EncryptedUsername AND c.EncryptedPassword = @EncryptedPassword;
