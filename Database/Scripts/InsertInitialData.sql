IF (SELECT COUNT(*) FROM Users) = 0
BEGIN
    INSERT INTO Users
        (Username, Password, Address, Email, Phone, SecondaryLogonPriority, NeededSecondaryLogonPriority, Fullname)
    VALUES
        ('Sziltech', 'abrakadabra', '4029 Debrecen, Fényes udvar 3. 8. em. 48.', 'info@sziltech.hu', '(52) 452 172', 100, 0, 'Sziltech Electronic Kft'),
        ('admin', 'adminpass', NULL, NULL, NULL, 100, 0, NULL);

    INSERT INTO Groups
        (Name, OtherInformation, ParentGroupId)
    VALUES 
        ('BUILTIN_DEV_GRP', 'Beépített csoport a Sziltech Electronic Kft. munkatársai számára', NULL),
        ('BUILTIN_ADMIN_GRP', 'Beépített csoport a rendszer adminisztrátorainak', 1);

    INSERT INTO UsersInGroups
        (UserId, GroupId)
    VALUES 
        (1, 1),
        (2, 2);

    INSERT INTO Options
        (Name, TypeId, Value, UserId)
    VALUES 
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

    INSERT INTO Options
        (Name, TypeId, Value, UserId)
    VALUES
        ('last_language_id', 2, '1', 1),
        ('active_event', 2, '1', 1),
        ('active_template_id', 2, '0', 1),
        ('language_id', 2, '2', 1),
        ('language_id', 2, '2', 2);

    INSERT INTO Options
        (Name, TypeId, Value, UserId)
    VALUES 
        ('font_type', 3, 'Arial', 1),
        ('font_type', 3, 'Arial', 2),
	    ('no_signal_file', 3, '', 1),
        ('no_signal_file_hash', 3, '', 1);

    INSERT INTO Options
        (Name, TypeId, Value, UserId)
    VALUES 
        ('font_size', 8, '8.25', 1),
        ('font_size', 8, '8.25', 2);

    INSERT INTO Options
        (Name, TypeId, Value, UserId)
    VALUES 
        ('use_watchdog', 0, 'True', 1),
        ('motion_popup_isopened', 0, 'False', 1),
        ('enable_threading', 0, 'True', 1),
        ('is_controller_opened', 0, 'True', 1),
        ('is_controller_opened', 0, 'True', 2);

    INSERT INTO UserEvents
        (Name, Note)
    VALUES
        ('Alaphelyzet', 'Nincs sem pozitív, sem negatív elbírálás a felhasználókkal szemben.');

    INSERT INTO LoggedinUser
        (UserId)
    VALUES
        ('SOWnGHe9ogk='),
        ('SOWnGHe9ogk=');

    INSERT INTO BSOptions
        (LcidIn, LcidOut, MaxDelay, CustomIn, CustomOut, SerialScanner, SelectedComPort)
    VALUES
        (1038, 1033, 50, 0, 0, 0, -1);

    INSERT INTO BSCharChanger
        (Id, Chars)
    VALUES
        (1033, '`1234567890-=qwertyuiop[]asdfghjkl;''\\\\zxcvbnm,./ ~!@#$%&*()_+QWERTYUIOP{}ASDFGHJKL\"||ZXCVBNM<>? '),
        (1038, '0123456789öüóqwertzuiopőúasdfghjkléáűíyxcvbnm,.- §''\"+!%/=()ÖÜÓQWERTZUIOPŐÚASDFGHJKLÉÁŰÍYXCVBNM?_ ');
END;
