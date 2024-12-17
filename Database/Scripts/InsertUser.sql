INSERT INTO Users (
    username, password, fullname, address, email, telephone, carsign, 
    barcode, other_information, picture, secondary_logon_priority, 
    needed_secondary_logon_priority, checksum
)
VALUES (
    @username, @password, @fullname, @address, @email, @telephone, @carsign, 
    @barcode, @other_information, @picture, @secondary_logon_priority, 
    @needed_secondary_logon_priority, @checksum
);