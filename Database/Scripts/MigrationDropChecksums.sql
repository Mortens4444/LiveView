IF EXISTS (SELECT * FROM sys.columns
           WHERE object_id = OBJECT_ID(N'[dbo].[Cameras]') AND name = 'checksum')
BEGIN
    ALTER TABLE CameraPermissions DROP COLUMN checksum;
    ALTER TABLE Cameras DROP COLUMN checksum;
    ALTER TABLE DBServers DROP COLUMN checksum;
    ALTER TABLE Displays DROP COLUMN checksum;
    ALTER TABLE Events DROP COLUMN checksum;
    ALTER TABLE GridCameralist DROP COLUMN checksum;
    ALTER TABLE Grids DROP COLUMN checksum;
    ALTER TABLE GridsInSequences DROP COLUMN checksum;
    ALTER TABLE Groups DROP COLUMN checksum;
    ALTER TABLE IOPorts DROP COLUMN checksum;
    ALTER TABLE IOPortsLogs DROP COLUMN checksum;
    ALTER TABLE IOPortsRules DROP COLUMN checksum;
    ALTER TABLE LanguageElements DROP COLUMN checksum;
    ALTER TABLE Languages DROP COLUMN checksum;
    ALTER TABLE Logs DROP COLUMN checksum;
    ALTER TABLE Operations DROP COLUMN checksum;
    ALTER TABLE Permissions DROP COLUMN checksum;
    ALTER TABLE Sequences DROP COLUMN checksum;
    ALTER TABLE Servers DROP COLUMN checksum;
    ALTER TABLE ServerStates DROP COLUMN checksum;
    ALTER TABLE Users DROP COLUMN checksum;
    ALTER TABLE UserEvents DROP COLUMN checksum;
    ALTER TABLE UsersInGroups DROP COLUMN checksum;
END;