SELECT s.*, vc.Username, vc.EncryptedPassword AS Password, wc.Username AS WinUser, wc.EncryptedPassword as WinPass FROM Servers AS s
LEFT JOIN Credentials AS vc ON s.VideoServerCredentialsId = vc.Id
LEFT JOIN Credentials AS wc ON s.WindowsCredentialsId = wc.Id
ORDER BY Hostname