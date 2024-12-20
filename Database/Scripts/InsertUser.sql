INSERT INTO Users (
    Username, Password, Fullname, Address, Email, Phone, LicensePlate, 
    Barcode, OtherInformation, Image, SecondaryLogonPriority, 
    NeededSecondaryLogonPriority
)
VALUES (
    @Username, @Password, @Fullname, @Address, @Email, @Phone, @LicensePlate, 
    @Barcode, @OtherInformation, @Image, @SecondaryLogonPriority, 
    @NeededSecondaryLogonPriority
);