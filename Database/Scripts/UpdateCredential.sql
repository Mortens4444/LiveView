UPDATE Credentials SET
	EncryptedUsername = @EncryptedUsername,
	EncryptedPassword = @EncryptedPassword,
	CredentialType = @CredentialType
WHERE Id = @Id;