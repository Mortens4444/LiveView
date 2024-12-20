SELECT Id, Username, Password, FullName, Address, Email, Phone, LicensePlate, 
    Barcode, OtherInformation, Image, SecondaryLogonPriority, NeededSecondaryLogonPriority
FROM Users
ORDER BY Username;