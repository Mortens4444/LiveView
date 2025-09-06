INSERT INTO Credentials
	(EncryptedUsername, EncryptedPassword, CredentialType)
VALUES
	(@EncryptedUsername, @EncryptedPassword, @CredentialType);