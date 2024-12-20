IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Cameras_Servers'
)
BEGIN
    ALTER TABLE Cameras
    ADD CONSTRAINT FK_Cameras_Servers FOREIGN KEY (serverid) REFERENCES Servers(Id) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_GridsInSequences_Sequences'
)
BEGIN
    ALTER TABLE GridsInSequences
    ADD CONSTRAINT FK_GridsInSequences_Sequences
    FOREIGN KEY (sequenceid) REFERENCES Sequences(Id) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_GridsInSequences_Grids'
)
BEGIN
    ALTER TABLE GridsInSequences
    ADD CONSTRAINT FK_GridsInSequences_Grids
    FOREIGN KEY (gridid) REFERENCES Grids(Id) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_GridCameralist_Cameras'
)
BEGIN
    ALTER TABLE Grid_cameralist
    ADD CONSTRAINT FK_GridCameralist_Cameras
    FOREIGN KEY (camera_id) REFERENCES Cameras(Id) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_GridCameralist_Grids'
)
BEGIN
    ALTER TABLE Grid_cameralist
    ADD CONSTRAINT FK_GridCameralist_Grids
    FOREIGN KEY (grid_id) REFERENCES Grids(Id) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Options_Users'
)
BEGIN
    ALTER TABLE Options
    ADD CONSTRAINT FK_Options_Users
    FOREIGN KEY (user_id) REFERENCES Users(Id) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Groups_ParentGroup'
)
BEGIN
    ALTER TABLE Groups
    ALTER COLUMN parent_group_id BIGINT NULL;

    UPDATE Groups SET parent_group_id = NULL WHERE parent_group_id = 0;

    ALTER TABLE Groups
    ADD CONSTRAINT FK_Groups_ParentGroup
    FOREIGN KEY (parent_group_id) REFERENCES Groups(Id)
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_FormPositions_Template'
)
BEGIN
    ALTER TABLE FormPositions
    ADD CONSTRAINT FK_FormPositions_Template
    FOREIGN KEY (template_id) REFERENCES Templates(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Images_Camera'
)
BEGIN
    ALTER TABLE Pictures
    ADD CONSTRAINT FK_Images_Camera
    FOREIGN KEY (camera_id) REFERENCES Cameras(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_ObjectsInMaps_Map'
)
BEGIN
    ALTER TABLE ObjectsInMaps
    ADD CONSTRAINT FK_ObjectsInMaps_Map
    FOREIGN KEY (MapId) REFERENCES Maps(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_ObjectsInMaps_MapObject'
)
BEGIN
    ALTER TABLE ObjectsInMaps
    ADD CONSTRAINT FK_ObjectsInMaps_MapObject
    FOREIGN KEY (MapObjectId) REFERENCES MapObjects(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Logs_Event'
)
BEGIN
    ALTER TABLE Logs
    ADD CONSTRAINT FK_Logs_Event
    FOREIGN KEY (event_id) REFERENCES Events(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Logs_User'
)
BEGIN
    ALTER TABLE Logs
    ADD CONSTRAINT FK_Logs_User
    FOREIGN KEY (user_id) REFERENCES Users(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Logs_Operation'
)
BEGIN
    ALTER TABLE Logs
    ADD CONSTRAINT FK_Logs_Operation
    FOREIGN KEY (operation_id) REFERENCES Operations(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Permissions_Group'
)
BEGIN
    ALTER TABLE Rights
    ADD CONSTRAINT FK_Permissions_Group
    FOREIGN KEY (group_id) REFERENCES Groups(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Permissions_Operation'
)
BEGIN
    ALTER TABLE Rights
    ADD CONSTRAINT FK_Permissions_Operation
    FOREIGN KEY (operation_id) REFERENCES Operations(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Permissions_UserEvents'
)
BEGIN
    ALTER TABLE Rights
    ADD CONSTRAINT FK_Permissions_UserEvents
    FOREIGN KEY (user_event) REFERENCES Events(Id)
    ON DELETE CASCADE
    ON UPDATE NO ACTION;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_LanguageElements_Language'
)
BEGIN
    ALTER TABLE LanguageElements
    ADD CONSTRAINT FK_LanguageElements_Language
    FOREIGN KEY (language_id) REFERENCES Languages(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_LanguageElements_User'
)
BEGIN
    ALTER TABLE LanguageElements
    ADD CONSTRAINT FK_LanguageElements_User
    FOREIGN KEY (user_id) REFERENCES Users(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_ServerStates_Server'
)
BEGIN
    ALTER TABLE ServerStates
    ADD CONSTRAINT FK_ServerStates_Server
    FOREIGN KEY (server_id) REFERENCES Servers(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_IOPortsRules_Operation'
)
BEGIN
    ALTER TABLE IOPorts_Rules
    ADD CONSTRAINT FK_IOPortsRules_Operation
    FOREIGN KEY (operation_id) REFERENCES Operations(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_IOPortsRules_Event'
)
BEGIN
    ALTER TABLE IOPorts_Rules
    ADD CONSTRAINT FK_IOPortsRules_Event
    FOREIGN KEY (event_id) REFERENCES Events(Id);
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_UsersInGroups_User'
)
BEGIN
    ALTER TABLE UsersInGroups
    ADD CONSTRAINT FK_UsersInGroups_User
    FOREIGN KEY (user_id) REFERENCES Users(Id)
    ON DELETE CASCADE
    ON UPDATE NO ACTION;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_UsersInGroups_Group'
)
BEGIN
    ALTER TABLE UsersInGroups
    ADD CONSTRAINT FK_UsersInGroups_Group
    FOREIGN KEY (group_id) REFERENCES Groups(Id)
    ON DELETE CASCADE
    ON UPDATE NO ACTION;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_CameraPermissions_Cameras'
)
BEGIN
    ALTER TABLE RightsOnCameras
    ADD CONSTRAINT FK_CameraPermissions_Cameras
    FOREIGN KEY (camera_id) REFERENCES Cameras(Id)
    ON DELETE CASCADE
    ON UPDATE NO ACTION;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_CameraPermissions_Groups'
)
BEGIN
    ALTER TABLE RightsOnCameras
    ADD CONSTRAINT FK_CameraPermissions_Groups
    FOREIGN KEY (group_id) REFERENCES Groups(Id)
    ON DELETE CASCADE
    ON UPDATE NO ACTION;
END;

IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = 'FK_CameraPermissions_Events'
)
BEGIN
    ALTER TABLE RightsOnCameras
    ADD CONSTRAINT FK_CameraPermissions_Events
    FOREIGN KEY (user_event) REFERENCES Events(Id)
    ON DELETE CASCADE
    ON UPDATE NO ACTION;
END;

IF NOT EXISTS (SELECT * 
               FROM sys.foreign_keys 
               WHERE name = 'FK_RgCfRuleReadingGroups')
BEGIN
    ALTER TABLE RgCfRule
    ADD CONSTRAINT FK_RgCfRuleReadingGroups
    FOREIGN KEY (RG_ID) REFERENCES ReadingGroups(ID);
END;

IF NOT EXISTS (SELECT * 
               FROM sys.foreign_keys 
               WHERE name = 'FK_RgCfRule_Rules')
BEGIN
    ALTER TABLE RgCfRule
    ADD CONSTRAINT FK_RgCfRule_Rules
    FOREIGN KEY (R_ID) REFERENCES Rules(ID);
END;

IF NOT EXISTS (SELECT * 
               FROM sys.foreign_keys 
               WHERE name = 'FK_IOPortsLogs_Users')
BEGIN
    ALTER TABLE IOPorts_Logs
    ADD CONSTRAINT FK_IOPortsLogs_Users
    FOREIGN KEY (user_id) REFERENCES Users(Id);
END;
