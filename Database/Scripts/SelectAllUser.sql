SELECT 
    ID as Id, username as Username, password as Password, fullname as FullName, address as Address, email as Email, telephone as Telephone, carsign as LicensePlateNumber, 
    barcode as Barcode, other_information as OtherInformation, picture as Image, secondary_logon_priority as SecondaryLogonPriority, 
    needed_secondary_logon_priority as NeededSecondaryLogonPriority, checksum
FROM Users
ORDER BY username;