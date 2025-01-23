IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Agents]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].Agents (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ServerIp NVARCHAR(20) NOT NULL,
        VideoCaptureSourceName NVARCHAR(255) NOT NULL,
        Port INT NOT NULL
    );
END;