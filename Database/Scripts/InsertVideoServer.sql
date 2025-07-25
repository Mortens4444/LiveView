INSERT INTO Credentials (EncryptedUsername, EncryptedPassword, CredentialType)
VALUES (@EncryptedUsername, @EncryptedPassword, 4);

DECLARE @VSCredentialsId INT = SCOPE_IDENTITY();

INSERT INTO Credentials (EncryptedUsername, EncryptedPassword, CredentialType)
VALUES (@EncryptedWinUser, @EncryptedWinPass, 5);

DECLARE @WinCredentialsId INT = SCOPE_IDENTITY();

INSERT INTO VideoServers 
    (StartInMotionPopup, IpAddress, VideoServerCredentialsId, WindowsCredentialsId, Hostname, DongleSn, SerialNumber, MacAddress)
VALUES
    (@StartInMotionPopup, @IpAddress, @VSCredentialsId, @WinCredentialsId, @Hostname, @DongleSn, @SerialNumber, @MacAddress);