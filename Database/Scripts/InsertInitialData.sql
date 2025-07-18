IF (SELECT COUNT(*) FROM Users) = 0
BEGIN

    SET IDENTITY_INSERT Credentials ON;

    INSERT INTO Credentials (Id, Username, EncryptedPassword, CredentialType)
    VALUES
        (1, 'Sziltech', 'c0a071f7947fa1fe3170139666fc9c364021bc387bde89c68ba33f7d9e038502', 1), -- Plaintext password:   \-;!J401LnE|
        (2, 'admin', '591b16925313a3c1f7626ea8ac2669c9005b4f90abe7753da90245410ccf917e', 1); -- Plaintext password:   admin

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
