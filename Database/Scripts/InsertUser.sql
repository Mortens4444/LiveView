INSERT INTO Credentials (EncryptedUsername, EncryptedPassword, CredentialType)
VALUES (@EncryptedUsername, @EncryptedPassword, 1);

DECLARE @CredentialsId INT = SCOPE_IDENTITY();

INSERT INTO Users
    (LoginCredentialsId, Fullname, Address, Email, Phone, LicensePlate,
    Barcode, OtherInformation, Image, SecondaryLogonPriority,
    NeededSecondaryLogonPriority)
VALUES
    (@CredentialsId, @Fullname, @Address, @Email, @Phone, @LicensePlate,
    @Barcode, @OtherInformation, @Image, @SecondaryLogonPriority,
    @NeededSecondaryLogonPriority);