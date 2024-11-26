IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LiveView')
BEGIN

    CREATE DATABASE LiveView
    ON PRIMARY
    (
        NAME = LiveView_Data,
        FILENAME = 'C:\Databases\LiveView.mdf',
        SIZE = 2GB,
        MAXSIZE = 2GB,
        FILEGROWTH = 10%
    )
    LOG ON
    (
        NAME = LiveView_Log,
        FILENAME = 'C:\Databases\LiveView.ldf',
        SIZE = 5MB,
        MAXSIZE = 500MB,
        FILEGROWTH = 1MB
    );

END;