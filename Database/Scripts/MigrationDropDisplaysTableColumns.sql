IF EXISTS (SELECT * FROM sys.columns
           WHERE object_id = OBJECT_ID(N'[dbo].[Displays]') AND name = 'LittleX')
BEGIN
    ALTER TABLE Displays DROP COLUMN LittleX;
    ALTER TABLE Displays DROP COLUMN LittleY;
    ALTER TABLE Displays DROP COLUMN LittleWidth;
    ALTER TABLE Displays DROP COLUMN LittleHeight;
    ALTER TABLE Displays DROP COLUMN MainForm;
    ALTER TABLE Displays DROP COLUMN DeviceId;
END;