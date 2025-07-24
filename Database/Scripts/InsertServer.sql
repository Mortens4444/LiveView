INSERT INTO Credentials (Username, EncryptedPassword, CredentialType)
VALUES (@Username, @Password, 4);

DECLARE @VSCredentialsId INT = SCOPE_IDENTITY();

INSERT INTO Credentials (Username, EncryptedPassword, CredentialType)
VALUES (@WinUser, @WinPass, 5);

DECLARE @WinCredentialsId INT = SCOPE_IDENTITY();

INSERT INTO Servers 
    (StartInMotionPopup, IpAddress, VideoServerCredentialsId, WindowsCredentialsId, Hostname, DongleSn, SerialNumber, MacAddress)
VALUES
    (@StartInMotionPopup, @IpAddress, @VSCredentialsId, @WinCredentialsId, @Hostname, @DongleSn, @SerialNumber, @MacAddress);