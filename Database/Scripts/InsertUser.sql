INSERT INTO Credentials (Username, EncryptedPassword, CredentialType)
VALUES (@Username, @Password, 1);

DECLARE @LoginCredentialsId INT = SCOPE_IDENTITY();

INSERT INTO Users
    (LoginCredentialsId, Fullname, Address, Email, Phone, LicensePlate,
    Barcode, OtherInformation, Image, SecondaryLogonPriority,
    NeededSecondaryLogonPriority)
VALUES
    (@LoginCredentialsId, @Fullname, @Address, @Email, @Phone, @LicensePlate,
    @Barcode, @OtherInformation, @Image, @SecondaryLogonPriority,
    @NeededSecondaryLogonPriority);