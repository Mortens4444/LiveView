INSERT INTO Credentials (EncryptedUsername, EncryptedPassword, CredentialType)
VALUES (@EncryptedUsername, @EncryptedPassword, 3);

DECLARE @DBServerCredentialsId INT = SCOPE_IDENTITY();

INSERT INTO DatabaseServers 
    (IpAddress, DatabaseServerCredentialsId, Hostname, DbName, DbPort, MacAddress)
VALUES
    (@IpAddress, @DBServerCredentialsId, @Hostname, @DbName, @DbPort, @MacAddress);