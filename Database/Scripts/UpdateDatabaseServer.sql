UPDATE DatabaseServers SET
	IpAddress = @IpAddress,
	Hostname = @Hostname,
	DbName = @DbName,
	DbPort = @DbPort,
	MacAddress = @MacAddress
WHERE Id = @Id;

UPDATE Credentials SET 
    EncryptedUsername = @EncryptedUsername,
    EncryptedPassword = @EncryptedPassword
WHERE Id = @DatabaseServerCredentialsId;