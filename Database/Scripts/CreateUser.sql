IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LiveView')
BEGIN

    IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'Ceronit\morte')
    BEGIN
        CREATE LOGIN [Ceronit\morte] FROM WINDOWS;
    END;

    IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'Ceronit\morte')
    BEGIN
        USE LiveView;
        CREATE USER [Ceronit\morte] FOR LOGIN [Ceronit\morte];
        EXEC sp_addrolemember N'db_owner', N'Ceronit\morte';
    END;

END;