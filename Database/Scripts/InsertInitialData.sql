IF (SELECT COUNT(*) FROM Users) = 0
BEGIN

    SET IDENTITY_INSERT Credentials ON;

    INSERT INTO Credentials (Id, EncryptedUsername, EncryptedPassword, CredentialType)
    VALUES
        (1, @SziltechUserName, '81d2c3b1ad3f54ad6d0f5792282c9eaf2784352ec3f6f2144c061768235ae64e', 1), -- \-;!J401LnE|
        (2, @AdminUserName, '97a524ee5f747a16446a0c15edc47613f395ab7fd6719d2cde96e636808f81b1', 1); -- admin

    SET IDENTITY_INSERT Credentials OFF;

    SET IDENTITY_INSERT Users ON;

    INSERT INTO Users
        (Id, LoginCredentialsId, Address, Email, Phone, SecondaryLogonPriority, NeededSecondaryLogonPriority, Fullname)
    VALUES
        (1, 1, '4029 Debrecen, Fényes udvar 3. 8. em. 48.', 'info@sziltech.hu', '+36 52 452 172', 100, 0, 'Sziltech Electronic Kft'),
        (2, 2, NULL, NULL, NULL, 100, 0, NULL);

    SET IDENTITY_INSERT Users OFF;

    SET IDENTITY_INSERT Groups ON;

    INSERT INTO Groups
        (Id, Name, OtherInformation, ParentGroupId)
    VALUES 
        (1, 'BUILTIN_DEV_GRP', 'Beépített csoport a Sziltech Electronic Kft. munkatársai számára', NULL),
        (2, 'BUILTIN_ADMIN_GRP', 'Beépített csoport a rendszer adminisztrátorainak', 1);
    
    SET IDENTITY_INSERT Groups OFF;

    INSERT INTO GroupMembers
        (UserId, GroupId)
    VALUES 
        (1, 1),
        (2, 2);

    SET IDENTITY_INSERT UserEvents ON;

    INSERT INTO UserEvents
        (Id, Name, Note)
    VALUES
        (1, 'Alaphelyzet', 'Nincs sem pozitív, sem negatív elbírálás a felhasználókkal szemben.');
    
    SET IDENTITY_INSERT UserEvents OFF; 

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
