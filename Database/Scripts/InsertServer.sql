INSERT INTO Credentials (Username, EncryptedPassword, CredentialType)
VALUES (@Username, @Password, 4);

DECLARE @VideoServerCredentialsId INT = SCOPE_IDENTITY();

INSERT INTO Credentials (Username, EncryptedPassword, CredentialType)
VALUES (@WinUser, @WinPass, 5);

DECLARE @WindowsCredentialsId INT = SCOPE_IDENTITY();

INSERT INTO Servers 
    (StartInMotionPopup, IpAddress, VideoServerCredentialsId, WindowsCredentialsId, Hostname, DongleSn, SerialNumber, MacAddress)
VALUES
    (@StartInMotionPopup, @IpAddress, @VideoServerCredentialsId, @WindowsCredentialsId, @Hostname, @DongleSn, @SerialNumber, @MacAddress);