UPDATE VideoServers SET
	IpAddress = @IpAddress,
	Hostname = @Hostname,
	DongleSn = @DongleSn,
	SerialNumber = @SerialNumber,
	MacAddress = @MacAddress
WHERE Id = @Id;

UPDATE Credentials SET 
    EncryptedUsername = @EncryptedUsername,
    EncryptedPassword = @EncryptedPassword
WHERE Id = @VideoServerCredentialsId;

UPDATE Credentials SET 
    EncryptedUsername = @EncryptedWinUser,
    EncryptedPassword = @EncryptedWinPass
WHERE Id = @WindowsCredentialsId;