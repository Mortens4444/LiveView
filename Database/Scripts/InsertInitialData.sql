IF (SELECT COUNT(*) FROM Users) = 0
BEGIN
    INSERT INTO Users
        (Username, Password, Address, Email, Phone, SecondaryLogonPriority, NeededSecondaryLogonPriority, Fullname)
    VALUES
        ('Sziltech', 'abrakadabra', '4029 Debrecen, Fényes udvar 3. 8. em. 48.', 'info@sziltech.hu', '(52) 452 172', 100, 0, 'Sziltech Electronic Kft'),
        ('admin', 'adminpass', NULL, NULL, NULL, 100, 0, NULL);

    INSERT INTO Groups
        (Name, OtherInformation, ParentGroupId)
    VALUES 
        ('BUILTIN_DEV_GRP', 'Beépített csoport a Sziltech Electronic Kft. munkatársai számára', NULL),
        ('BUILTIN_ADMIN_GRP', 'Beépített csoport a rendszer adminisztrátorainak', 1);

    INSERT INTO UsersInGroups
        (UserId, GroupId)
    VALUES 
        (1, 1),
        (2, 2);

    INSERT INTO UserEvents
        (Name, Note)
    VALUES
        ('Alaphelyzet', 'Nincs sem pozitív, sem negatív elbírálás a felhasználókkal szemben.');

    INSERT INTO BSOptions
        (LcidIn, LcidOut, MaxDelay, CustomIn, CustomOut, SerialScanner, SelectedComPort)
    VALUES
        (1038, 1033, 50, 0, 0, 0, -1);

    INSERT INTO BSCharChanger
        (Id, Chars)
    VALUES
        (1033, '`1234567890-=qwertyuiop[]asdfghjkl;''\\\\zxcvbnm,./ ~!@#$%&*()_+QWERTYUIOP{}ASDFGHJKL\"||ZXCVBNM<>? '),
        (1038, '0123456789öüóqwertzuiopőúasdfghjkléáűíyxcvbnm,.- §''\"+!%/=()ÖÜÓQWERTZUIOPŐÚASDFGHJKLÉÁŰÍYXCVBNM?_ ');
END;
