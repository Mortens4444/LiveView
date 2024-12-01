IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Servers]') AND type in (N'U'))
BEGIN
    CREATE TABLE Servers (
        ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        iporhost NVARCHAR(100) NOT NULL,
        username NVARCHAR(100) NOT NULL,
        password NVARCHAR(100) NOT NULL,
        displayed_name NVARCHAR(100) NOT NULL,
        dongle_sn NVARCHAR(20) NULL,
        sziltech_sn NVARCHAR(20) NULL,
        mac_address NVARCHAR(20) NULL,
        win_user NVARCHAR(100) NULL,
        win_pass NVARCHAR(100) NULL,
        start_in_motion_popup BIT NOT NULL DEFAULT 1,
        checksum NVARCHAR(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cameras]') AND type in (N'U'))
BEGIN
    CREATE TABLE Cameras (
        ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        serverid BIGINT NOT NULL,
        cameraname NVARCHAR(100) NOT NULL,
        guid NVARCHAR(50) NOT NULL,
        priority INT NULL,
        checksum NVARCHAR(200) NULL,
        recorder_index BIGINT NOT NULL,
        partner_camera_id BIGINT NULL,
        motion_trigger BIGINT NULL,
        motion_trigger_minimum_length BIGINT NULL,
        ip_address NVARCHAR(200) NULL,
        stream_id INT NULL,
        http_stream_url NVARCHAR(200) NULL,
        username NVARCHAR(200) NULL,
        password NVARCHAR(200) NULL,
        fullscreen_mode INT NOT NULL DEFAULT 0
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grids]') AND type in (N'U'))
BEGIN
    CREATE TABLE Grids (
        ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        rows INT NOT NULL,
        columns INT NOT NULL,
        pixelsfromright INT NOT NULL,
        pixelsfrombottom INT NOT NULL,
        name NVARCHAR(50) NOT NULL,
        priority INT NULL,
        checksum NVARCHAR(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sequences]') AND type in (N'U'))
BEGIN
    CREATE TABLE Sequences (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        name nvarchar(50) NOT NULL,
        active bit NOT NULL,
        priority int NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GridsInSequences]') AND type in (N'U'))
BEGIN
    CREATE TABLE GridsInSequences (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        sequenceid bigint NOT NULL,
        gridid bigint NOT NULL,
        timetoshow int NOT NULL,
        number int NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grid_cameralist]') AND type in (N'U'))
BEGIN
    CREATE TABLE Grid_cameralist (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        grid_id bigint NOT NULL,
        camera_id bigint NOT NULL,
        init_row int NOT NULL,
        init_col int NOT NULL,
        end_row int NULL,
        end_col int NULL,
        osd bit NOT NULL,
        frame bit NOT NULL,
        [left] int NULL,
        [top] int NULL,
        width int NULL,
        height int NULL,
        checksum nvarchar(200) NULL,
        ptz bit NOT NULL,
        motion_save_images bit NOT NULL,
        motion_number_of_photos int NOT NULL,
        motion_value int NOT NULL,
        csr_save_images bit NOT NULL,
        csr_number_of_photos int NOT NULL,
        csr_value int NOT NULL,
        show_date_time bit NOT NULL DEFAULT 0
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
        monitor_name nvarchar(256) NULL,
        adapter_name nvarchar(256) NULL,
        device_name nvarchar(256) NULL,
        sziltech_id nvarchar(30) NOT NULL,
        isprimary bit NULL,
        removable bit NULL,
        attachedtodesktop bit NULL,
        mainform bit NULL,
        fullscreen bit NULL,
        can_show_sequence bit NULL,
        can_show_fullscreen bit NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Options]') AND type in (N'U'))
BEGIN
    CREATE TABLE Options (
        name NVARCHAR(50) NOT NULL,
        type_id TINYINT NOT NULL,
        value NVARCHAR(256),
        user_id BIGINT NOT NULL,
        PRIMARY KEY (name, user_id)
    );

    INSERT INTO Options (name, type_id, value, user_id) VALUES 
        ('log_level', 1, '0', 1),
        ('wait_for_server', 1, '5000', 1),
        ('timebetweenlastandfirstserver', 1, '3000', 1),
        ('joy_x', 1, '0', 1),
        ('joy_y', 1, '0', 1),
        ('joy_z', 1, '0', 1),
        ('cc_ofs', 1, '0', 1),
        ('sf_ofs', 1, '1', 1),
        ('stat_msg_interval', 1, '1440', 1),
        ('autologin_interval', 1, '0', 1),
        ('max_cam_deflection', 1, '5000', 1),
        ('max_wait_to_new_picture', 1, '300', 1),
        ('foreground_color', 1, '-1', 1),
        ('foreground_color', 1, '-1', 2),
        ('shadow_color', 1, '-16777216', 1),
        ('shadow_color', 1, '-16777216', 2),
        ('camera_caption', 1, '1', 1),
        ('camera_caption', 1, '1', 2),
        ('font_size_big', 1, '18', 1),
        ('font_size_big', 1, '18', 2),
        ('font_size_small', 1, '8', 1),
        ('font_size_small', 1, '8', 2),
        ('controller_style', 1, '1', 1),
        ('controller_style', 1, '0', 2),
	    ('identify_seconds', 1, '5', 1),
        ('identify_seconds', 1, '5', 2),
        ('mainformx', 1, '0', 1),
        ('mainformy', 1, '0', 1),
        ('mainformw', 1, '230', 1),
        ('mainformh', 1, '840', 1),
        ('controlformx', 1, '0', 1),
        ('controlformy', 1, '0', 1),
        ('controlformw', 1, '290', 1),
        ('controlformh', 1, '900', 1),
        ('panel1h', 1, '166', 1),
        ('panel3h', 1, '164', 1),
        ('panel2h', 1, '153', 1),
        ('panel4h', 1, '135', 1),
        ('restart_template', 1, 240, 1),
        ('motion_popup_location_x', 1, 100, 1),
        ('motion_popup_location_y', 1, 100, 1),
        ('motion_popup_width', 1, 640, 1),
        ('motion_popup_height', 1, 480, 1),
        ('mp_upper_panel_height', 1, 540, 1);

    INSERT INTO Options (name, type_id, value, user_id) VALUES 
        ('last_language_id', 2, '1', 1),
        ('active_event', 2, '1', 1),
        ('active_template_id', 2, '0', 1),
        ('language_id', 2, '2', 1),
        ('language_id', 2, '2', 2);

    INSERT INTO Options (name, type_id, value, user_id) VALUES 
        ('font_type', 3, 'Arial', 1),
        ('font_type', 3, 'Arial', 2),
	    ('no_signal_file', 3, '', 1),
        ('no_signal_file_hash', 3, '', 1);

    INSERT INTO Options (name, type_id, value, user_id) VALUES 
        ('font_size', 8, '8.25', 1),
        ('font_size', 8, '8.25', 2);

    INSERT INTO Options (name, type_id, value, user_id) VALUES 
        ('use_watchdog', 0, 'True', 1),
        ('motion_popup_isopened', 0, 'False', 1),
        ('enable_threading', 0, 'True', 1),
        ('is_controller_opened', 0, 'True', 1),
        ('is_controller_opened', 0, 'True', 2);
END;


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE Users (
        ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        username NVARCHAR(100) NOT NULL,
        password NVARCHAR(200) NOT NULL,
        fullname NVARCHAR(100) NULL,
        address NVARCHAR(200) NULL,
        email NVARCHAR(200) NULL,
        telephone NVARCHAR(50) NULL,
        carsign NVARCHAR(50) NULL,
        barcode NVARCHAR(50) NULL,
        other_information NVARCHAR(MAX) NULL,
        picture IMAGE NULL,
        secondary_logon_priority INT NOT NULL,
        needed_secondary_logon_priority INT NOT NULL,
        checksum NVARCHAR(200) NULL
    );

    INSERT INTO Users (username, password, address, email, telephone, secondary_logon_priority, needed_secondary_logon_priority, fullname) VALUES
        ('Sziltech', 'abrakadabra', '4029 Debrecen, Fényes udvar 3. 8. em. 48.', 'info@sziltech.hu', '(52) 452 172', 100, 0, 'Sziltech Electronic Kft'),
        ('admin', 'adminpass', NULL, NULL, NULL, 100, 0, NULL);

END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Groups]') AND type in (N'U'))
BEGIN
    CREATE TABLE Groups (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        name nvarchar(100) NOT NULL,
        other_information nvarchar(MAX) NULL,
        parent_group_id bigint NOT NULL,
        checksum nvarchar(200) NULL
    );

    INSERT INTO Groups (name, other_information, parent_group_id) VALUES 
        ('BUILTIN_DEV_GRP', 'Beépített csoport a Sziltech Electronic Kft. munkatársai számára', 0),
        ('BUILTIN_ADMIN_GRP', 'Beépített csoport a rendszer adminisztrátorainak', 1);

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
        [name] nvarchar(100) NULL,
        flag image NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LanguageElements]') AND type in (N'U'))
BEGIN
    CREATE TABLE LanguageElements (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        note nvarchar(MAX) NULL,
        date datetime NOT NULL,
        language_id bigint NOT NULL,
        element_id bigint NOT NULL,
        value nvarchar(MAX) NOT NULL,
        user_id bigint NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Logs]') AND type in (N'U'))
BEGIN
    CREATE TABLE Logs (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        date datetime NOT NULL,
        user_id bigint NOT NULL,
        operation_id bigint NULL,
        event_id bigint NULL,
        language_element_id bigint NULL,
        other_information nvarchar(MAX) NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsersInGroups]') AND type in (N'U'))
BEGIN
    CREATE TABLE UsersInGroups (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        user_id bigint NOT NULL,
        group_id bigint NOT NULL,
        checksum nvarchar(200) NULL
    );

    INSERT INTO UsersInGroups (user_id, group_id) VALUES 
        (1, 1),
        (2, 2);

END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserEvents]') AND type in (N'U'))
BEGIN
    CREATE TABLE UserEvents (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        name nvarchar(100) NOT NULL,
        note nvarchar(MAX) NULL,
        checksum nvarchar(200) NULL
    );

    INSERT INTO UserEvents (name, note) VALUES
        ('Alaphelyzet', 'Nincs sem pozitív, sem negatív elbírálás a felhasználókkal szemben.');

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
        store_date datetime NOT NULL,
        event_date datetime NOT NULL,
        img image NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Templates]') AND type in (N'U'))
BEGIN
    CREATE TABLE Templates (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        template_name nvarchar(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FormPositions]') AND type in (N'U'))
BEGIN
    CREATE TABLE FormPositions (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        template_id bigint NOT NULL,
        form_id bigint NOT NULL,
        secondary_id bigint NULL,
        isopened bit NOT NULL,
        x int NOT NULL,
        y int NOT NULL,
        w int NOT NULL,
        h int NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogedinUser]') AND type in (N'U'))
BEGIN
    CREATE TABLE LogedinUser (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        user_id nvarchar(200) NOT NULL,
        login_date datetime NULL
    );

    INSERT INTO LogedinUser (user_id) VALUES
        ('SOWnGHe9ogk='),
        ('SOWnGHe9ogk=');

END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Databases]') AND type in (N'U'))
BEGIN
    CREATE TABLE Databases (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        name nvarchar(100) NOT NULL,
        path nvarchar(250) NOT NULL,
        isexists bit NOT NULL,
        isactive bit NOT NULL,
        isarchived bit NOT NULL,
        fromdate datetime NULL,
        todate datetime NULL,
        filename nvarchar(250) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadingGroups]') AND type in (N'U'))
BEGIN
    CREATE TABLE ReadingGroups (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        name nvarchar(50) NOT NULL,
        description nvarchar(MAX) NOT NULL
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
        lcid_in int NOT NULL,
        lcid_out int NOT NULL,
        max_delay int NOT NULL,
        custom_in int NOT NULL,
        custom_out int NOT NULL,
        serial_scanner bit NOT NULL,
        selected_com_port int NOT NULL
    );

    INSERT INTO BSOptions (lcid_in, lcid_out, max_delay, custom_in, custom_out, serial_scanner, selected_com_port) VALUES
        (1038, 1033, 50, 0, 0, 0, -1);

END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSCharChanger]') AND type in (N'U'))
BEGIN
    CREATE TABLE BSCharChanger (
        ID bigint NOT NULL PRIMARY KEY,
        chars nvarchar(255) NOT NULL
    );

    INSERT INTO BSCharChanger (ID, chars) VALUES
        (1033, '`1234567890-=qwertyuiop[]asdfghjkl;''\\\\zxcvbnm,./ ~!@#$%&*()_+QWERTYUIOP{}ASDFGHJKL\"||ZXCVBNM<>? '),
        (1038, '0123456789öüóqwertzuiopőúasdfghjkléáűíyxcvbnm,.- §''\"+!%/=()ÖÜÓQWERTZUIOPŐÚASDFGHJKLÉÁŰÍYXCVBNM?_ ');
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pass_readings]') AND type in (N'U'))
BEGIN
    CREATE TABLE Pass_readings (
        ID bigint NOT NULL PRIMARY KEY,
        date1 datetime NOT NULL,
        date2 datetime NOT NULL,
        date3 datetime NOT NULL,
        date4 datetime NOT NULL,
        value nvarchar(255) NOT NULL,
        sender nvarchar(255) NOT NULL,
        senders_listener_port int NOT NULL,
        acknowledge bit NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBServers]') AND type in (N'U'))
BEGIN
    CREATE TABLE DBServers (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        iporhost nvarchar(100) NOT NULL,
        db_name nvarchar(100) NOT NULL,
        username nvarchar(100) NOT NULL,
        password nvarchar(100) NOT NULL,
        displayed_name nvarchar(100) NOT NULL,
        mac_address nvarchar(20) NULL,
        db_port int NOT NULL,
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
        port_num int NOT NULL,
        name nvarchar(255) NOT NULL,
        friendly_name nvarchar(255) NOT NULL,
        direction int NOT NULL,
        state int NOT NULL,
        min_trigger_time int NOT NULL,
        max_count int NOT NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IOPorts_Logs]') AND type in (N'U'))
BEGIN
    CREATE TABLE IOPorts_Logs (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        device_id int NOT NULL,
        port_num int NOT NULL,
        state int NOT NULL,
        date datetime NOT NULL,
        user_id bigint NOT NULL,
        note nvarchar(MAX) NULL,
        checksum nvarchar(200) NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IOPorts_Rules]') AND type in (N'U'))
BEGIN
    CREATE TABLE IOPorts_Rules (
        ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        device_id int NOT NULL,
        port_num int NOT NULL,
        operation_id bigint NULL,
        event_id bigint NULL,
        zero_signaled bit NOT NULL,
        checksum nvarchar(200) NULL
    );
END;
