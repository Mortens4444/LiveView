IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Servers]') AND type in (N'U'))
BEGIN
    CREATE TABLE Servers (
        ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        displayed_name NVARCHAR(100) NOT NULL,
        dongle_sn NVARCHAR(20) NULL,
        sziltech_sn NVARCHAR(20) NULL,
        iporhost NVARCHAR(100) NOT NULL,
        mac_address NVARCHAR(20) NULL,
        start_in_motion_popup BIT NOT NULL DEFAULT 1,
        username NVARCHAR(100) NOT NULL,
        password NVARCHAR(100) NOT NULL,
        win_user NVARCHAR(100) NULL,
        win_pass NVARCHAR(100) NULL,
        checksum NVARCHAR(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cameras]') AND type in (N'U'))
BEGIN
    CREATE TABLE Cameras (
        ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        serverid BIGINT NOT NULL,
        partner_camera_id BIGINT NULL,
        stream_id INT NULL,
        recorder_index BIGINT NOT NULL,
        cameraname NVARCHAR(100) NOT NULL,
        fullscreen_mode INT NOT NULL DEFAULT 0,
        guid NVARCHAR(50) NOT NULL,
        http_stream_url NVARCHAR(200) NULL,
        ip_address NVARCHAR(200) NULL,
        motion_trigger BIGINT NULL,
        motion_trigger_minimum_length BIGINT NULL,
        priority INT NULL,
        username NVARCHAR(200) NULL,
        password NVARCHAR(200) NULL,
        checksum NVARCHAR(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grids]') AND type in (N'U'))
BEGIN
    CREATE TABLE Grids (
        ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        rows INT NOT NULL,
        columns INT NOT NULL,
        name NVARCHAR(50) NOT NULL,
        pixelsfrombottom INT NOT NULL,
        pixelsfromright INT NOT NULL,
        priority INT NULL,
        checksum NVARCHAR(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sequences]') AND type in (N'U'))
BEGIN
    CREATE TABLE Sequences (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        active bit NOT NULL,
        name nvarchar(50) NOT NULL,
        priority int NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GridsInSequences]') AND type in (N'U'))
BEGIN
    CREATE TABLE GridsInSequences (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        gridid bigint NOT NULL,
        sequenceid bigint NOT NULL,
        number int NOT NULL,
        timetoshow int NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects 
               WHERE object_id = OBJECT_ID(N'[dbo].[Grid_cameralist]') AND type = N'U')
    AND NOT EXISTS (SELECT * FROM sys.objects 
                   WHERE object_id = OBJECT_ID(N'[dbo].[WantedLicensePlates]') AND type = N'U')
BEGIN
    CREATE TABLE Grid_cameralist (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        camera_id bigint NOT NULL,
        grid_id bigint NOT NULL,
        init_row int NOT NULL,
        init_col int NOT NULL,
        end_row int NULL,
        end_col int NULL,
        [left] int NULL,
        [top] int NULL,
        width int NULL,
        height int NULL,
        csr_save_images bit NOT NULL,
        csr_number_of_photos int NOT NULL,
        csr_value int NOT NULL,
        frame bit NOT NULL,
        osd bit NOT NULL,
        show_date_time bit NOT NULL DEFAULT 0,
        ptz bit NOT NULL,
        motion_save_images bit NOT NULL,
        motion_number_of_photos int NOT NULL,
        motion_value int NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Monitors]') AND type in (N'U'))
BEGIN
    CREATE TABLE Monitors (
        ID bigint NOT NULL PRIMARY KEY,
        device_id bigint NOT NULL,
        x int NOT NULL,
        y int NOT NULL,
        width int NOT NULL,
        height int NOT NULL,
        maxwidth int NOT NULL,
        maxheight int NOT NULL,
        little_x int NULL,
        little_y int NULL,
        little_width int NULL,
        little_height int NULL,
        adapter_name nvarchar(256) NULL,
        device_name nvarchar(256) NULL,
        monitor_name nvarchar(256) NULL,
        sziltech_id nvarchar(30) NOT NULL,
        attachedtodesktop bit NULL,
        can_show_fullscreen bit NULL,
        can_show_sequence bit NULL,
        isprimary bit NULL,
        mainform bit NULL,
        removable bit NULL,
        fullscreen bit NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Options]') AND type in (N'U'))
BEGIN
    CREATE TABLE Options (
        name NVARCHAR(50) NOT NULL,
        user_id BIGINT NOT NULL,
        type_id TINYINT NOT NULL,
        value NVARCHAR(256),
        PRIMARY KEY (name, user_id)
    );
END;


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE Users (
        ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        address NVARCHAR(200) NULL,
        barcode NVARCHAR(50) NULL,
        carsign NVARCHAR(50) NULL,
        email NVARCHAR(200) NULL,
        fullname NVARCHAR(100) NULL,
        picture IMAGE NULL,
        needed_secondary_logon_priority INT NOT NULL,
        other_information NVARCHAR(MAX) NULL,
        secondary_logon_priority INT NOT NULL,
        telephone NVARCHAR(50) NULL,
        username NVARCHAR(100) NOT NULL,
        password NVARCHAR(200) NOT NULL,
        checksum NVARCHAR(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Groups]') AND type in (N'U'))
BEGIN
    CREATE TABLE Groups (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        parent_group_id bigint NOT NULL,
        name nvarchar(100) NOT NULL,
        other_information nvarchar(MAX) NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rights]') AND type in (N'U'))
BEGIN
    CREATE TABLE Rights (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        operation_id bigint NOT NULL,
        group_id bigint NOT NULL,
        user_event bigint NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Operations]') AND type in (N'U'))
BEGIN
    CREATE TABLE Operations (
        ID bigint NOT NULL PRIMARY KEY,
        language_element_id bigint NOT NULL,
        note nvarchar(100) NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Events]') AND type in (N'U'))
BEGIN
    CREATE TABLE Events (
        ID bigint NOT NULL PRIMARY KEY,
        language_element_id bigint NOT NULL,
        note nvarchar(100) NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Languages]') AND type in (N'U'))
BEGIN
    CREATE TABLE Languages (
        ID bigint NOT NULL PRIMARY KEY,
        flag image NULL,
        [name] nvarchar(100) NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LanguageElements]') AND type in (N'U'))
BEGIN
    CREATE TABLE LanguageElements (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        user_id bigint NULL,
        language_id bigint NOT NULL,
        element_id bigint NOT NULL,
        date datetime NOT NULL,
        note nvarchar(MAX) NULL,
        value nvarchar(MAX) NOT NULL,
        checksum nvarchar(200) NULL
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

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MapObjects]') AND type in (N'U'))
BEGIN
    CREATE TABLE MapObjects (
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

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObjectsInMaps]') AND type in (N'U'))
BEGIN
    CREATE TABLE ObjectsInMaps (
        MapId INT NOT NULL,
        MapObjectId INT NOT NULL,
        PRIMARY KEY (MapId, MapObjectId)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Logs]') AND type in (N'U'))
BEGIN
    CREATE TABLE Logs (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        event_id bigint NULL,
        operation_id bigint NULL,
        user_id bigint NOT NULL,
        language_element_id bigint NULL,
        date datetime NOT NULL,
        other_information nvarchar(MAX) NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsersInGroups]') AND type in (N'U'))
BEGIN
    CREATE TABLE UsersInGroups (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        group_id bigint NOT NULL,
        user_id bigint NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserEvents]') AND type in (N'U'))
BEGIN
    CREATE TABLE UserEvents (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        name nvarchar(100) NOT NULL,
        note nvarchar(MAX) NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RightsOnCameras]') AND type in (N'U'))
BEGIN
    CREATE TABLE RightsOnCameras (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        camera_id bigint NOT NULL,
        group_id bigint NOT NULL,
        user_event bigint NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pictures]') AND type in (N'U'))
BEGIN
    CREATE TABLE Pictures (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        camera_id bigint NOT NULL,
        event_date datetime NOT NULL,
        img image NOT NULL,
        store_date datetime NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Templates]') AND type in (N'U'))
BEGIN
    CREATE TABLE Templates (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        template_name nvarchar(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TemplateProcesses]') AND type in (N'U'))
BEGIN
    CREATE TABLE TemplateProcesses (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        TemplateId BIGINT NOT NULL,
        ProcessName NVARCHAR(50) NOT NULL,
        ProcessParameters NVARCHAR(250) NOT NULL,
        FOREIGN KEY (TemplateId) REFERENCES Templates(Id)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects 
               WHERE object_id = OBJECT_ID(N'[dbo].[LogedinUser]') AND type = N'U')
    AND NOT EXISTS (SELECT * FROM sys.objects 
                   WHERE object_id = OBJECT_ID(N'[dbo].[WantedLicensePlates]') AND type = N'U')
BEGIN
    CREATE TABLE LogedinUser (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        user_id nvarchar(200) NOT NULL,
        login_date datetime NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Databases]') AND type in (N'U'))
BEGIN
    CREATE TABLE Databases (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        name nvarchar(100) NOT NULL,
        filename nvarchar(250) NOT NULL,
        path nvarchar(250) NOT NULL,
        isexists bit NOT NULL,
        isactive bit NOT NULL,
        isarchived bit NOT NULL,
        fromdate datetime NULL,
        todate datetime NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadingGroups]') AND type in (N'U'))
BEGIN
    CREATE TABLE ReadingGroups (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        description nvarchar(MAX) NOT NULL,
        name nvarchar(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rules]') AND type in (N'U'))
BEGIN
    CREATE TABLE Rules (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        name nvarchar(50) NOT NULL,
        rulestr nvarchar(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RgCfRule]') AND type in (N'U'))
BEGIN
    CREATE TABLE RgCfRule (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        RG_ID bigint NOT NULL,
        R_ID bigint NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSReadings]') AND type in (N'U'))
BEGIN
    CREATE TABLE BSReadings (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        date datetime NOT NULL,
        value nvarchar(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSOptions]') AND type in (N'U'))
BEGIN
    CREATE TABLE BSOptions (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        custom_in int NOT NULL,
        custom_out int NOT NULL,
        lcid_in int NOT NULL,
        lcid_out int NOT NULL,
        max_delay int NOT NULL,
        selected_com_port int NOT NULL,
        serial_scanner bit NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSCharChanger]') AND type in (N'U'))
BEGIN
    CREATE TABLE BSCharChanger (
        ID bigint NOT NULL PRIMARY KEY,
        chars nvarchar(255) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects 
               WHERE object_id = OBJECT_ID(N'[dbo].[Pass_readings]') AND type = N'U')
    AND NOT EXISTS (SELECT * FROM sys.objects 
                   WHERE object_id = OBJECT_ID(N'[dbo].[WantedLicensePlates]') AND type = N'U')
BEGIN
    CREATE TABLE Pass_readings (
        ID bigint NOT NULL PRIMARY KEY,
        acknowledge bit NOT NULL,
        date1 datetime NOT NULL,
        date2 datetime NOT NULL,
        date3 datetime NOT NULL,
        date4 datetime NOT NULL,
        sender nvarchar(255) NOT NULL,
        senders_listener_port int NOT NULL,
        value nvarchar(255) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBServers]') AND type in (N'U'))
BEGIN
    CREATE TABLE DBServers (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        iporhost nvarchar(100) NOT NULL,
        db_name nvarchar(100) NOT NULL,
        db_port int NOT NULL,
        displayed_name nvarchar(100) NOT NULL,
        mac_address nvarchar(20) NULL,
        username nvarchar(100) NOT NULL,
        password nvarchar(100) NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ServerStates]') AND type in (N'U'))
BEGIN
    CREATE TABLE ServerStates (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        server_id bigint NOT NULL,
        last_state bigint NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IOPorts]') AND type in (N'U'))
BEGIN
    CREATE TABLE IOPorts (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        device_id int NOT NULL,
        direction int NOT NULL,
        friendly_name nvarchar(255) NOT NULL,
        min_trigger_time int NOT NULL,
        max_count int NOT NULL,
        name nvarchar(255) NOT NULL,
        port_num int NOT NULL,
        state int NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects 
               WHERE object_id = OBJECT_ID(N'[dbo].[IOPorts_Logs]') AND type = N'U')
    AND NOT EXISTS (SELECT * FROM sys.objects 
                   WHERE object_id = OBJECT_ID(N'[dbo].[WantedLicensePlates]') AND type = N'U')
BEGIN
    CREATE TABLE IOPorts_Logs (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        user_id bigint NOT NULL,
        device_id int NOT NULL,
        date datetime NOT NULL,
        note nvarchar(MAX) NULL,
        port_num int NOT NULL,
        state int NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects 
               WHERE object_id = OBJECT_ID(N'[dbo].[IOPorts_Rules]') AND type = N'U')
    AND NOT EXISTS (SELECT * FROM sys.objects 
                   WHERE object_id = OBJECT_ID(N'[dbo].[WantedLicensePlates]') AND type = N'U')
BEGIN
    CREATE TABLE IOPorts_Rules (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        operation_id bigint NULL,
        event_id bigint NULL,
        device_id int NOT NULL,
        port_num int NOT NULL,
        zero_signaled bit NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WantedLicensePlates]') AND type in (N'U'))
BEGIN
    CREATE TABLE WantedLicensePlates (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        DateReported datetime NULL,
        Description nvarchar(MAX) NULL,
        LicensePlate nvarchar(20) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ServerCredentials]') AND type in (N'U'))
BEGIN
    CREATE TABLE ServerCredentials (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ServerId BIGINT,
        CredentialType INT,
        Username NVARCHAR(200),
        EncryptedPassword NVARCHAR(MAX),
        FOREIGN KEY (ServerId) REFERENCES Servers(Id)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBServerCredentials]') AND type in (N'U'))
BEGIN
    CREATE TABLE DBServerCredentials (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ServerId BIGINT,
        CredentialType INT,
        Username NVARCHAR(200),
        EncryptedPassword NVARCHAR(MAX),
        FOREIGN KEY (ServerId) REFERENCES DBServers(Id)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserCredentials]') AND type in (N'U'))
BEGIN
    CREATE TABLE UserCredentials (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserId BIGINT,
        CredentialType INT,
        Username NVARCHAR(200),
        EncryptedPassword NVARCHAR(MAX),
        FOREIGN KEY (UserId) REFERENCES Users(Id)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Migrations]') AND type in (N'U'))
BEGIN
    CREATE TABLE Migrations (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(200)
    );
END;