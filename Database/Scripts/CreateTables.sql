IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Credentials]') AND type in (N'U'))
BEGIN
    CREATE TABLE Credentials (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CredentialType INT,
        Username NVARCHAR(MAX),
        EncryptedPassword NVARCHAR(MAX)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Servers]') AND type in (N'U'))
BEGIN
    CREATE TABLE Servers (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Hostname NVARCHAR(100) NOT NULL,
        DongleSn NVARCHAR(20) NULL,
        SerialNumber NVARCHAR(20) NULL,
        IpAddress NVARCHAR(100) NOT NULL,
        MacAddress NVARCHAR(20) NULL,
        StartInMotionPopup BIT NOT NULL DEFAULT 1,
        VideoServerCredentialsId INT NULL,
        WindowsCredentialsId INT NULL,
        FOREIGN KEY (VideoServerCredentialsId) REFERENCES Credentials(Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
        FOREIGN KEY (WindowsCredentialsId) REFERENCES Credentials(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Agents]') AND type = N'U')
BEGIN
    CREATE TABLE Agents (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ServerIp NVARCHAR(200),
        AgentPort INT NOT NULL,
        VncServerPort INT NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VideoSources]') AND type in (N'U'))
BEGIN
    CREATE TABLE VideoSources (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        AgentId INT,
        Name NVARCHAR(500),
        Port INT NOT NULL,
        FOREIGN KEY (AgentId) REFERENCES Agents(Id)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cameras]') AND type in (N'U'))
BEGIN
    CREATE TABLE Cameras (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ServerId INT NOT NULL,
        PartnerCameraId INT NULL,
        CameraCredentialsId INT NULL,
        VideoSourceId INT NULL,
        StreamId INT NULL,
        RecorderIndex BIGINT NOT NULL,
        CameraName NVARCHAR(100) NOT NULL,
        FullscreenMode INT NOT NULL DEFAULT 0,
        Guid NVARCHAR(50) NOT NULL,
        HttpStreamUrl NVARCHAR(500) NULL,
        IpAddress NVARCHAR(200) NULL,
        MotionTrigger BIGINT NULL,
        MotionTriggerMinimumLength BIGINT NULL,
        Priority INT NULL,
        PermissionCamera INT NOT NULL DEFAULT 0,
        FOREIGN KEY (ServerId) REFERENCES Servers(Id) ON DELETE CASCADE,
        FOREIGN KEY (VideoSourceId) REFERENCES VideoSources(Id) ON DELETE SET NULL,
        FOREIGN KEY (PartnerCameraId) REFERENCES Cameras(Id) ON DELETE NO ACTION,
        FOREIGN KEY (CameraCredentialsId) REFERENCES Credentials(Id) ON DELETE CASCADE ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grids]') AND type in (N'U'))
BEGIN
    CREATE TABLE Grids (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Rows INT NOT NULL,
        Columns INT NOT NULL,
        Name NVARCHAR(500) NOT NULL,
        PixelsFromBottom INT NOT NULL,
        PixelsFromRight INT NOT NULL,
        Priority INT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sequences]') AND type in (N'U'))
BEGIN
    CREATE TABLE Sequences (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Active BIT NOT NULL,
        Name NVARCHAR(500) NOT NULL,
        Priority INT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SequenceGrids]') AND type in (N'U'))
BEGIN
    CREATE TABLE SequenceGrids (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        GridId INT NOT NULL,
        SequenceId INT NOT NULL,
        Number INT NOT NULL,
        TimeToShow INT NOT NULL,
        FOREIGN KEY (GridId) REFERENCES Grids(Id) ON DELETE CASCADE,
        FOREIGN KEY (SequenceId) REFERENCES Sequences(Id) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FlaggedLicensePlates]') AND type = N'U')
BEGIN
    CREATE TABLE FlaggedLicensePlates (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        LicensePlate NVARCHAR(50) NOT NULL,
        DateReported DATETIME NULL,
        Description NVARCHAR(MAX) NULL
    );
END;


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GridCameras]') AND type = N'U')
BEGIN
    CREATE TABLE GridCameras (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CameraId INT NULL,
        GridId INT NOT NULL,
        InitRow INT NOT NULL,
        InitCol INT NOT NULL,
        EndRow INT NULL,
        EndCol INT NULL,
        [Left] INT NULL,
        [Top] INT NULL,
        Width INT NULL,
        Height INT NULL,
        CsrSaveImages BIT NOT NULL,
        CsrNumberOfPhotos INT NOT NULL,
        CsrValue INT NOT NULL,
        Frame BIT NOT NULL,
        Osd BIT NOT NULL,
        ShowDateTime BIT NOT NULL DEFAULT 0,
        Ptz BIT NOT NULL,
        MotionSaveImages BIT NOT NULL,
        MotionNumberOfPhotos INT NOT NULL,
        MotionValue INT NOT NULL,
        CameraMode INT NOT NULL DEFAULT 0,
        FOREIGN KEY (GridId) REFERENCES Grids(Id) ON DELETE CASCADE,
        FOREIGN KEY (CameraId) REFERENCES Cameras(Id) ON DELETE SET NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Displays]') AND type in (N'U'))
BEGIN
    CREATE TABLE Displays (
        Id INT NOT NULL PRIMARY KEY,
        X INT NOT NULL,
        Y INT NOT NULL,
        Width INT NOT NULL,
        Height INT NOT NULL,
        MaxWidth INT NOT NULL,
        MaxHeight INT NOT NULL,
        AdapterName NVARCHAR(256) NULL,
        DeviceName NVARCHAR(256) NULL,
        MonitorName NVARCHAR(256) NULL,
        SziltechId NVARCHAR(30) NOT NULL,
        AttachedToDesktop BIT NULL,
        CanShowFullscreen BIT NULL,
        CanShowSequence BIT NULL,
        IsPrimary BIT NULL,
        Removable BIT NULL,
        Fullscreen BIT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE Users (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Address NVARCHAR(200) NULL,
        Barcode NVARCHAR(50) NULL,
        LicensePlate NVARCHAR(50) NULL,
        Email NVARCHAR(200) NULL,
        Fullname NVARCHAR(100) NULL,
        Image VARBINARY(MAX) NULL,
        NeededSecondaryLogonPriority INT NOT NULL,
        OtherInformation NVARCHAR(MAX) NULL,
        SecondaryLogonPriority INT NOT NULL,
        Phone NVARCHAR(50) NULL,
        LoginCredentialsId INT NULL,
        FOREIGN KEY (LoginCredentialsId) REFERENCES Credentials(Id) ON DELETE CASCADE ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Options]') AND type in (N'U'))
BEGIN
    CREATE TABLE Options (
        Name NVARCHAR(50) NOT NULL,
        UserId INT NOT NULL,
        TypeId TINYINT NOT NULL,
        Value NVARCHAR(256) NULL,
        PRIMARY KEY (Name, UserId),
        FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Groups]') AND type in (N'U'))
BEGIN
    CREATE TABLE Groups (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ParentGroupId INT NULL,
        Name NVARCHAR(100) NOT NULL,
        OtherInformation NVARCHAR(MAX) NULL,
        FOREIGN KEY (ParentGroupId) REFERENCES Groups(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserEvents]') AND type in (N'U'))
BEGIN
    CREATE TABLE UserEvents (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        Note NVARCHAR(MAX) NULL,
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Operations]') AND type in (N'U'))
BEGIN
    CREATE TABLE Operations (
        Id INT NOT NULL PRIMARY KEY,
        PermissionGroup NVARCHAR(255) NOT NULL,
        PermissionValue NVARCHAR(255) NOT NULL,
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permissions]') AND type in (N'U'))
BEGIN
    CREATE TABLE Permissions (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        OperationId INT NOT NULL,
        GroupId INT NOT NULL,
        UserEventId INT NOT NULL,
        FOREIGN KEY (OperationId) REFERENCES Operations(Id) ON DELETE CASCADE ON UPDATE NO ACTION,
        FOREIGN KEY (UserEventId) REFERENCES UserEvents(Id) ON DELETE CASCADE ON UPDATE NO ACTION,
        FOREIGN KEY (GroupId) REFERENCES Groups(Id) ON DELETE CASCADE ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Maps]') AND type in (N'U'))
BEGIN
    CREATE TABLE Maps (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Comment NVARCHAR(MAX) NOT NULL,
        Name NVARCHAR(MAX) NOT NULL,
        MapImage VARBINARY(MAX) NULL,
        OriginalWidth INT NOT NULL,
        OriginalHeight INT NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ActionObjects]') AND type in (N'U'))
BEGIN
    CREATE TABLE ActionObjects (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ActionReferencedId INT NOT NULL,
        ActionType INT NOT NULL,
        Comment NVARCHAR(MAX) NOT NULL,
        Image VARBINARY(MAX) NULL,
        X INT NOT NULL,
        Y INT NOT NULL,
        Width INT NOT NULL,
        Height INT NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MapActionObjects]') AND type in (N'U'))
BEGIN
    CREATE TABLE MapActionObjects (
        MapId INT NOT NULL,
        ActionObjectId INT NOT NULL,
        PRIMARY KEY (MapId, ActionObjectId),
        FOREIGN KEY (MapId) REFERENCES Maps(Id) ON DELETE CASCADE,
        FOREIGN KEY (ActionObjectId) REFERENCES ActionObjects(Id) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Logs]') AND type in (N'U'))
BEGIN
    CREATE TABLE Logs (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserEventId INT NULL,
        OperationId INT NULL,
        UserId INT NOT NULL,
        Date DATETIME NOT NULL,
        OtherInformation NVARCHAR(MAX) NULL,
        FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
        FOREIGN KEY (UserEventId) REFERENCES UserEvents(Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
        FOREIGN KEY (OperationId) REFERENCES Operations(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupMembers]') AND type in (N'U'))
BEGIN
    CREATE TABLE GroupMembers (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        GroupId INT NOT NULL,
        UserId INT NOT NULL,
        FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE ON UPDATE NO ACTION,
        FOREIGN KEY (GroupId) REFERENCES Groups(Id) ON DELETE CASCADE ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CameraPermissions]') AND type in (N'U'))
BEGIN
    CREATE TABLE CameraPermissions (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CameraId INT NOT NULL,
        GroupId INT NOT NULL,
        UserEventId INT NOT NULL,
        FOREIGN KEY (CameraId) REFERENCES Cameras(Id) ON DELETE CASCADE ON UPDATE NO ACTION,
        FOREIGN KEY (GroupId) REFERENCES Groups(Id) ON DELETE CASCADE ON UPDATE NO ACTION,
        FOREIGN KEY (UserEventId) REFERENCES UserEvents(Id) ON DELETE CASCADE ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SavedImages]') AND type in (N'U'))
BEGIN
    CREATE TABLE SavedImages (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CameraId INT NOT NULL,
        EventDate DATETIME NOT NULL,
        Image VARBINARY(MAX) NOT NULL,
        StoreDate DATETIME NOT NULL,
        FOREIGN KEY (CameraId) REFERENCES Cameras(Id)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Templates]') AND type in (N'U'))
BEGIN
    CREATE TABLE Templates (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        TemplateName NVARCHAR(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TemplateProcesses]') AND type in (N'U'))
BEGIN
    CREATE TABLE TemplateProcesses (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        TemplateId INT NOT NULL,
        AgentId INT NULL,
        ProcessName NVARCHAR(50) NOT NULL,
        ProcessParameters NVARCHAR(250) NOT NULL,
        FOREIGN KEY (TemplateId) REFERENCES Templates(Id),
		FOREIGN KEY (AgentId) REFERENCES Agents(Id) ON DELETE SET NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Databases]') AND type in (N'U'))
BEGIN
    CREATE TABLE Databases (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        FileName NVARCHAR(250) NOT NULL,
        Path NVARCHAR(250) NOT NULL,
        IsExists BIT NOT NULL,
        IsActive BIT NOT NULL,
        IsArchived BIT NOT NULL,
        FromDate DATETIME NULL,
        ToDate DATETIME NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadingGroups]') AND type in (N'U'))
BEGIN
    CREATE TABLE ReadingGroups (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Description NVARCHAR(MAX) NOT NULL,
        Name NVARCHAR(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rules]') AND type in (N'U'))
BEGIN
    CREATE TABLE Rules (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(50) NOT NULL,
        RuleStr NVARCHAR(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RgCfRule]') AND type in (N'U'))
BEGIN
    CREATE TABLE RgCfRule (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ReadingGroupId INT NOT NULL,
        RuleId INT NOT NULL,
        FOREIGN KEY (RuleId) REFERENCES Rules(Id),
        FOREIGN KEY (ReadingGroupId) REFERENCES ReadingGroups(Id)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSReadings]') AND type in (N'U'))
BEGIN
    CREATE TABLE BSReadings (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Date DATETIME NOT NULL,
        Value NVARCHAR(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSOptions]') AND type in (N'U'))
BEGIN
    CREATE TABLE BSOptions (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CustomIn INT NOT NULL,
        CustomOut INT NOT NULL,
        LcidIn INT NOT NULL,
        LcidOut INT NOT NULL,
        MaxDelay INT NOT NULL,
        SelectedComPort INT NOT NULL,
        SerialScanner BIT NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSCharChanger]') AND type in (N'U'))
BEGIN
    CREATE TABLE BSCharChanger (
        Id INT NOT NULL PRIMARY KEY,
        Chars NVARCHAR(255) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadLicensePlates]') AND type = N'U')
BEGIN
    CREATE TABLE ReadLicensePlates (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ReadDate DATETIME NOT NULL,
        LicensePlate NVARCHAR(50) NOT NULL,
        CameraId INT NOT NULL,
		FOREIGN KEY (CameraId) REFERENCES Cameras(Id)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DatabaseServers]') AND type in (N'U'))
BEGIN
    CREATE TABLE DatabaseServers (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        IpAddress NVARCHAR(100) NOT NULL,
        Hostname NVARCHAR(100) NOT NULL,
        DbName NVARCHAR(100) NOT NULL,
        DbPort INT NOT NULL,
        MacAddress NVARCHAR(20) NULL,
        DatabaseServerCredentialsId INT NULL,
        FOREIGN KEY (DatabaseServerCredentialsId) REFERENCES Credentials(Id) ON DELETE CASCADE ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IOPorts]') AND type in (N'U'))
BEGIN
    CREATE TABLE IOPorts (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        DeviceId INT NOT NULL,
        Direction INT NOT NULL,
        FriendlyName NVARCHAR(255) NOT NULL,
        MinTriggerTime INT NOT NULL,
        MaxCount INT NOT NULL,
        Name NVARCHAR(255) NOT NULL,
        PortNum INT NOT NULL,
        State INT NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IOPortsLogs]') AND type = N'U')
BEGIN
    CREATE TABLE IOPortsLogs (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserId INT NOT NULL,
        DeviceId INT NOT NULL,
        Date DATETIME NOT NULL,
        Note NVARCHAR(MAX) NULL,
        PortNum INT NOT NULL,
        State INT NOT NULL,
        FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IOPortsRules]') AND type = N'U')
BEGIN
    CREATE TABLE IOPortsRules (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        OperationId INT NULL,
        UserEventId INT NULL,
        DeviceId INT NOT NULL,
        PortNum INT NOT NULL,
        ZeroSignaled BIT NOT NULL,
        FOREIGN KEY (OperationId) REFERENCES Operations(Id) ON DELETE CASCADE ON UPDATE NO ACTION,
        FOREIGN KEY (UserEventId) REFERENCES UserEvents(Id) ON DELETE CASCADE ON UPDATE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Migrations]') AND type in (N'U'))
BEGIN
    CREATE TABLE Migrations (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(200)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CameraFunctions]') AND type in (N'U'))
BEGIN
    CREATE TABLE CameraFunctions (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CameraId INT,
        FunctionId INT,
        FunctionCallback NVARCHAR(MAX),
        FOREIGN KEY (CameraId) REFERENCES Cameras(Id)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CameraFunctionParams]') AND type in (N'U'))
BEGIN
    CREATE TABLE CameraFunctionParams (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CameraFunctionId INT NOT NULL,
        ParamIndex INT NOT NULL,
        ParamValue NVARCHAR(100) NULL,
        FOREIGN KEY (CameraFunctionId) REFERENCES CameraFunctions(Id) ON DELETE CASCADE
    );
END;