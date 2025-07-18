UPDATE Servers SET
	IpAddress = @IpAddress,
	Hostname = @Hostname,
	DongleSn = @DongleSn,
	SziltechSn = @SerialNumber,
	MacAddress = @MacAddress
WHERE Id = @Id;

UPDATE Credentials SET 
    Username = @Username,
    EncryptedPassword = @Password
WHERE Id = @VideoServerCredentialsId;

UPDATE Credentials SET 
    Username = @WinUser,
    EncryptedPassword = @WinPass
WHERE Id = @WindowsCredentialsId;