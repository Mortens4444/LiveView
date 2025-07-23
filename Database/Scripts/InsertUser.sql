INSERT INTO Credentials (Username, EncryptedPassword, CredentialType)
VALUES (@EncryptedUsername, @Password, 1);

DECLARE @CredentialsId INT = SCOPE_IDENTITY();

INSERT INTO Users
    (LoginCredentialsId, Fullname, Address, Email, Phone, LicensePlate,
    Barcode, OtherInformation, Image, SecondaryLogonPriority,
    NeededSecondaryLogonPriority)
VALUES
    (@CredentialsId, @Fullname, @Address, @Email, @Phone, @LicensePlate,
    @Barcode, @OtherInformation, @Image, @SecondaryLogonPriority,
    @NeededSecondaryLogonPriority);