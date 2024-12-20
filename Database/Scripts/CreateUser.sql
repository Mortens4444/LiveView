IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LiveView')
BEGIN
    DECLARE @CurrentUser NVARCHAR(128) = SYSTEM_USER;

    IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = @CurrentUser)
    BEGIN
        EXEC('CREATE LOGIN [' + @CurrentUser + '] FROM WINDOWS;');
    END;

    IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = @CurrentUser)
    BEGIN
        USE LiveView;
        EXEC('CREATE USER [' + @CurrentUser + '] FOR LOGIN [' + @CurrentUser + '];');
        EXEC('EXEC sp_addrolemember N''db_owner'', N''' + @CurrentUser + ''';');
    END;
END;