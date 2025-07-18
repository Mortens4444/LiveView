SELECT d.*, c.Username, c.EncryptedPassword AS Password FROM DatabaseServers AS d
LEFT JOIN Credentials AS c ON d.DatabaseServerCredentialsId = c.Id
ORDER BY Hostname