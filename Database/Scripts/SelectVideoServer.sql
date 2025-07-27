SELECT s.*, vc.EncryptedUsername, vc.EncryptedPassword, wc.EncryptedUsername AS EncryptedWinUser, wc.EncryptedPassword AS EncryptedWinPass FROM VideoServers AS s
LEFT JOIN Credentials AS vc ON s.VideoServerCredentialsId = vc.Id
LEFT JOIN Credentials AS wc ON s.WindowsCredentialsId = wc.Id
WHERE s.Id = @Id;