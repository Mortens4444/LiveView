IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GridCameralist]') AND type = N'U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GridCameras]') AND type = N'U')
    BEGIN
        EXEC sp_rename N'[dbo].[GridCameralist]', N'GridCameras';
    END
END;

IF NOT EXISTS (
    SELECT 1 
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'GridCameras' AND COLUMN_NAME = 'ServerIp'
)
BEGIN
    ALTER TABLE GridCameras ADD ServerIp NVARCHAR(20) NULL;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'GridCameras' AND COLUMN_NAME = 'VideoSourceName'
)
BEGIN
    ALTER TABLE GridCameras ADD VideoSourceName NVARCHAR(500) NULL;
END;

IF EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_GridCameralist_Cameras'
)
BEGIN
    ALTER TABLE GridCameras DROP CONSTRAINT FK_GridCameralist_Cameras;
END;

ALTER TABLE GridCameras ALTER COLUMN CameraId BIGINT NULL;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_GridCameralist_Cameras'
)
BEGIN
    ALTER TABLE GridCameras
    ADD CONSTRAINT FK_GridCameras_Cameras
    FOREIGN KEY (CameraId) REFERENCES Cameras(Id) ON DELETE CASCADE;
END;