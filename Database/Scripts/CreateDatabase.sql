IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LiveView')
BEGIN

    CREATE DATABASE LiveView
    ON PRIMARY
    (
        NAME = LiveView_Data,
        FILENAME = 'C:\Databases\LiveView2.mdf',
        SIZE = 10GB,
        MAXSIZE = 10GB,
        FILEGROWTH = 10%
    )
    LOG ON
    (
        NAME = LiveView_Log,
        FILENAME = 'C:\Databases\LiveView2.ldf',
        SIZE = 500MB,
        MAXSIZE = 500MB,
        FILEGROWTH = 1MB
    );

END;