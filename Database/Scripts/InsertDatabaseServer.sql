INSERT INTO Credentials (EncryptedUsername, EncryptedPassword, CredentialType)
VALUES (@EncryptedUsername, @EncryptedPassword, 3);

DECLARE @DatabaseServerCredentialsId INT = SCOPE_IDENTITY();

INSERT INTO DatabaseServers 
    (IpAddress, DatabaseServerCredentialsId, Hostname, DbName, DbPort, MacAddress)
VALUES
    (@IpAddress, @DatabaseServerCredentialsId, @Hostname, @DbName, @DbPort, @MacAddress);