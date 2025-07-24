UPDATE Servers SET
	IpAddress = @IpAddress,
	Hostname = @Hostname,
	DongleSn = @DongleSn,
	SerialNumber = @SerialNumber,
	MacAddress = @MacAddress
WHERE Id = @Id;

UPDATE Credentials SET 
    Username = @EncryptedUsername,
    EncryptedPassword = @Password
WHERE Id = @VideoServerCredentialsId;

UPDATE Credentials SET 
    Username = @EncryptedWinUser,
    EncryptedPassword = @WinPass
WHERE Id = @WindowsCredentialsId;