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
    Phone = @Phone,
    Username = @Username,
    Password = @Password
WHERE Id = @Id;