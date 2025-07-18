UPDATE [dbo].[Users]
SET
    Address = @Address,
    Barcode = @Barcode,
    LicensePlate = @LicensePlate,
    Email = @Email,
    Fullname = @FullName,
    Image = @Image,
    NeededSecondaryLogonPriority = @NeededSecondaryLogonPriority,
    OtherInformation = @OtherInformation,
    SecondaryLogonPriority = @SecondaryLogonPriority,
    Phone = @Phone
WHERE Id = @Id;

UPDATE Credentials SET 
    Username = @Username,
    EncryptedPassword = @Password
WHERE Id = @LoginCredentialsId;
