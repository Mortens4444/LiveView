-- C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LiveView')
BEGIN
    CREATE DATABASE LiveView
    ON PRIMARY
    (
        NAME = LiveView_Data,
        FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LiveView.mdf',
--        FILENAME = 'C:\Databases\LiveView.mdf',
        SIZE = 10GB,
        MAXSIZE = 10GB,
        FILEGROWTH = 10%
    )
    LOG ON
    (
        NAME = LiveView_Log,
        FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LiveView.ldf',
--        FILENAME = 'C:\Databases\LiveView.ldf',
        SIZE = 500MB,
        MAXSIZE = 500MB,
        FILEGROWTH = 1MB
    );

END;