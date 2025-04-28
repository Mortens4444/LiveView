IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Cameras' AND COLUMN_NAME = 'VideoSourceId')
BEGIN
    ALTER TABLE Cameras ADD VideoSourceId BIGINT NULL;
END

IF NOT EXISTS (
    SELECT 1
    FROM sys.foreign_keys fk
    JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
    JOIN sys.tables t ON fk.parent_object_id = t.object_id
    JOIN sys.columns c ON fkc.parent_column_id = c.column_id AND c.object_id = t.object_id
    WHERE t.name = 'Cameras' AND c.name = 'VideoSourceId'
)
BEGIN
    ALTER TABLE Cameras
    ADD CONSTRAINT FK_Cameras_VideoSources
    FOREIGN KEY (VideoSourceId) REFERENCES VideoSources(Id)
    ON DELETE SET NULL;
END

IF EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_GridCameras_Cameras'
)
BEGIN
    ALTER TABLE GridCameras DROP CONSTRAINT FK_GridCameras_Cameras;
END

ALTER TABLE GridCameras
ADD CONSTRAINT FK_GridCameras_Cameras
FOREIGN KEY (CameraId) REFERENCES Cameras(Id) ON DELETE SET NULL;
