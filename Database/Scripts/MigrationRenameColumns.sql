IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Cameras]') AND name = 'serverid')
BEGIN
    EXEC sp_rename 'dbo.BSCharChanger.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.BSCharChanger.chars', 'Chars', 'COLUMN';

    EXEC sp_rename 'dbo.BSOptions.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.BSOptions.custom_in', 'CustomIn', 'COLUMN';
    EXEC sp_rename 'dbo.BSOptions.custom_out', 'CustomOut', 'COLUMN';
    EXEC sp_rename 'dbo.BSOptions.lcid_in', 'LcidIn', 'COLUMN';
    EXEC sp_rename 'dbo.BSOptions.lcid_out', 'LcidOut', 'COLUMN';
    EXEC sp_rename 'dbo.BSOptions.max_delay', 'MaxDelay', 'COLUMN';
    EXEC sp_rename 'dbo.BSOptions.selected_com_port', 'SelectedComPort', 'COLUMN';
    EXEC sp_rename 'dbo.BSOptions.serial_scanner', 'SerialScanner', 'COLUMN';

    EXEC sp_rename 'dbo.BSReadings.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.BSReadings.date', 'Date', 'COLUMN';
    EXEC sp_rename 'dbo.BSReadings.value', 'Value', 'COLUMN';

    EXEC sp_rename 'dbo.CameraPermissions.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.CameraPermissions.camera_id', 'CameraId', 'COLUMN';
    EXEC sp_rename 'dbo.CameraPermissions.group_id', 'GroupId', 'COLUMN';
    EXEC sp_rename 'dbo.CameraPermissions.user_event', 'UserEvent', 'COLUMN';

    EXEC sp_rename 'dbo.Cameras.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.partner_camera_id', 'PartnerCameraId', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.serverid', 'ServerId', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.stream_id', 'StreamId', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.recorder_index', 'RecorderIndex', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.cameraname', 'CameraName', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.fullscreen_mode', 'FullscreenMode', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.guid', 'Guid', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.http_stream_url', 'HttpStreamUrl', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.ip_address', 'IpAddress', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.motion_trigger', 'MotionTrigger', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.motion_trigger_minimum_length', 'MotionTriggerMinimumLength', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.priority', 'Priority', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.username', 'Username', 'COLUMN';
    EXEC sp_rename 'dbo.Cameras.password', 'Password', 'COLUMN';

    EXEC sp_rename 'dbo.Databases.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Databases.name', 'Name', 'COLUMN';
    EXEC sp_rename 'dbo.Databases.path', 'Path', 'COLUMN';
    EXEC sp_rename 'dbo.Databases.filename', 'FileName', 'COLUMN';
    EXEC sp_rename 'dbo.Databases.isactive', 'IsActive', 'COLUMN';
    EXEC sp_rename 'dbo.Databases.isarchived', 'IsArchived', 'COLUMN';
    EXEC sp_rename 'dbo.Databases.isexists', 'IsExists', 'COLUMN';
    EXEC sp_rename 'dbo.Databases.fromdate', 'FromDate', 'COLUMN';
    EXEC sp_rename 'dbo.Databases.todate', 'ToDate', 'COLUMN';

    EXEC sp_rename 'dbo.DBServers.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.DBServers.IpOrHost', 'IporHost', 'COLUMN';
    EXEC sp_rename 'dbo.DBServers.db_name', 'DbName', 'COLUMN';
    EXEC sp_rename 'dbo.DBServers.db_port', 'DbPort', 'COLUMN';
    EXEC sp_rename 'dbo.DBServers.displayed_name', 'DisplayedName', 'COLUMN';
    EXEC sp_rename 'dbo.DBServers.mac_address', 'MacAddress', 'COLUMN';
    EXEC sp_rename 'dbo.DBServers.username', 'Username', 'COLUMN';
    EXEC sp_rename 'dbo.DBServers.password', 'Password', 'COLUMN';

    EXEC sp_rename 'dbo.Displays.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.device_id', 'DeviceId', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.x', 'X', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.y', 'Y', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.width', 'Width', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.height', 'Height', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.maxwidth', 'MaxWidth', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.maxheight', 'MaxHeight', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.little_x', 'LittleX', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.little_y', 'LittleY', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.little_width', 'LittleWidth', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.little_height', 'LittleHeight', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.adapter_name', 'AdapterName', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.device_name', 'DeviceName', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.monitor_name', 'MonitorName', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.sziltech_id', 'SziltechId', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.attachedtodesktop', 'AttachedToDesktop', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.can_show_fullscreen', 'CanShowFullscreen', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.can_show_sequence', 'CanShowSequence', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.fullscreen', 'Fullscreen', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.isprimary', 'IsPrimary', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.mainform', 'MainForm', 'COLUMN';
    EXEC sp_rename 'dbo.Displays.removable', 'Removable', 'COLUMN';

    EXEC sp_rename 'dbo.Events.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Events.language_element_id', 'LanguageElementId', 'COLUMN';
    EXEC sp_rename 'dbo.Events.note', 'Note', 'COLUMN';

    EXEC sp_rename 'dbo.GridCameralist.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.grid_id', 'GridId', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.camera_id', 'CameraId', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.init_row', 'InitRow', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.init_col', 'InitCol', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.end_row', 'EndRow', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.end_col', 'EndCol', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.left', 'Left', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.top', 'Top', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.width', 'Width', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.height', 'Height', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.frame', 'Frame', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.osd', 'Osd', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.ptz', 'Ptz', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.csr_save_images', 'CsrSaveImages', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.csr_number_of_photos', 'CsrNumberOfPhotos', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.csr_value', 'CsrValue', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.motion_save_images', 'MotionSaveImages', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.motion_number_of_photos', 'MotionNumberOfPhotos', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.motion_value', 'MotionValue', 'COLUMN';
    EXEC sp_rename 'dbo.GridCameralist.show_date_time', 'ShowDateTime', 'COLUMN';

    EXEC sp_rename 'dbo.Grids.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Grids.rows', 'Rows', 'COLUMN';
    EXEC sp_rename 'dbo.Grids.columns', 'Columns', 'COLUMN';
    EXEC sp_rename 'dbo.Grids.name', 'Name', 'COLUMN';
    EXEC sp_rename 'dbo.Grids.pixelsfromright', 'PixelsFromRight', 'COLUMN';
    EXEC sp_rename 'dbo.Grids.pixelsfrombottom', 'PixelsFromBottom', 'COLUMN';
    EXEC sp_rename 'dbo.Grids.priority', 'Priority', 'COLUMN';

    EXEC sp_rename 'dbo.GridsInSequences.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.GridsInSequences.sequenceid', 'SequenceId', 'COLUMN';
    EXEC sp_rename 'dbo.GridsInSequences.gridid', 'GridId', 'COLUMN';
    EXEC sp_rename 'dbo.GridsInSequences.number', 'Number', 'COLUMN';
    EXEC sp_rename 'dbo.GridsInSequences.timetoshow', 'TimeToShow', 'COLUMN';

    EXEC sp_rename 'dbo.Groups.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Groups.name', 'Name', 'COLUMN';
    EXEC sp_rename 'dbo.Groups.other_information', 'OtherInformation', 'COLUMN';
    EXEC sp_rename 'dbo.Groups.parent_group_id', 'ParentGroupId', 'COLUMN';

    EXEC sp_rename 'dbo.IOPorts.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.IOPorts.device_id', 'DeviceId', 'COLUMN';
    EXEC sp_rename 'dbo.IOPorts.direction', 'Direction', 'COLUMN';
    EXEC sp_rename 'dbo.IOPorts.friendly_name', 'FriendlyName', 'COLUMN';
    EXEC sp_rename 'dbo.IOPorts.min_trigger_time', 'MinTriggerTime', 'COLUMN';
    EXEC sp_rename 'dbo.IOPorts.max_count', 'MaxCount', 'COLUMN';
    EXEC sp_rename 'dbo.IOPorts.name', 'Name', 'COLUMN';
    EXEC sp_rename 'dbo.IOPorts.port_num', 'PortNum', 'COLUMN';
    EXEC sp_rename 'dbo.IOPorts.state', 'State', 'COLUMN';

    EXEC sp_rename 'dbo.IOPortsLogs.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsLogs.user_id', 'UserId', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsLogs.device_id', 'DeviceId', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsLogs.date', 'Date', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsLogs.note', 'Note', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsLogs.port_num', 'PortNum', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsLogs.state', 'State', 'COLUMN';

    EXEC sp_rename 'dbo.IOPortsRules.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsRules.operation_id', 'OperationId', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsRules.event_id', 'EventId', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsRules.device_id', 'DeviceId', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsRules.port_num', 'PortNum', 'COLUMN';
    EXEC sp_rename 'dbo.IOPortsRules.zero_signaled', 'ZeroSignaled', 'COLUMN';

    EXEC sp_rename 'dbo.LanguageElements.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.LanguageElements.language_id', 'LanguageId', 'COLUMN';
    EXEC sp_rename 'dbo.LanguageElements.element_id', 'ElementId', 'COLUMN';
    EXEC sp_rename 'dbo.LanguageElements.user_id', 'UserId', 'COLUMN';
    EXEC sp_rename 'dbo.LanguageElements.date', 'Date', 'COLUMN';
    EXEC sp_rename 'dbo.LanguageElements.note', 'Note', 'COLUMN';
    EXEC sp_rename 'dbo.LanguageElements.value', 'Value', 'COLUMN';

    EXEC sp_rename 'dbo.Languages.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Languages.flag', 'Flag', 'COLUMN';
    EXEC sp_rename 'dbo.Languages.name', 'Name', 'COLUMN';

    EXEC sp_rename 'dbo.Logs.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Logs.event_id', 'EventId', 'COLUMN';
    EXEC sp_rename 'dbo.Logs.operation_id', 'OperationId', 'COLUMN';
    EXEC sp_rename 'dbo.Logs.language_element_id', 'LanguageElementId', 'COLUMN';
    EXEC sp_rename 'dbo.Logs.user_id', 'UserId', 'COLUMN';
    EXEC sp_rename 'dbo.Logs.date', 'Date', 'COLUMN';
    EXEC sp_rename 'dbo.Logs.other_information', 'OtherInformation', 'COLUMN';

    EXEC sp_rename 'dbo.MapObjects.Id', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.MapObjects.ActionType', 'ActionType', 'COLUMN';
    EXEC sp_rename 'dbo.MapObjects.ActionReferencedId', 'ActionReferencedId', 'COLUMN';
    EXEC sp_rename 'dbo.MapObjects.Comment', 'Comment', 'COLUMN';
    EXEC sp_rename 'dbo.MapObjects.Image', 'Image', 'COLUMN';
    EXEC sp_rename 'dbo.MapObjects.X', 'X', 'COLUMN';
    EXEC sp_rename 'dbo.MapObjects.Y', 'Y', 'COLUMN';
    EXEC sp_rename 'dbo.MapObjects.Width', 'Width', 'COLUMN';
    EXEC sp_rename 'dbo.MapObjects.Height', 'Height', 'COLUMN';

    EXEC sp_rename 'dbo.Maps.Id', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Maps.Comment', 'Comment', 'COLUMN';
    EXEC sp_rename 'dbo.Maps.MapImage', 'MapImage', 'COLUMN';
    EXEC sp_rename 'dbo.Maps.Name', 'Name', 'COLUMN';
    EXEC sp_rename 'dbo.Maps.OriginalWidth', 'OriginalWidth', 'COLUMN';
    EXEC sp_rename 'dbo.Maps.OriginalHeight', 'OriginalHeight', 'COLUMN';

    EXEC sp_rename 'dbo.ObjectsInMaps.MapId', 'MapId', 'COLUMN';
    EXEC sp_rename 'dbo.ObjectsInMaps.MapObjectId', 'MapObjectId', 'COLUMN';

    EXEC sp_rename 'dbo.Operations.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Operations.language_element_id', 'LanguageElementId', 'COLUMN';
    EXEC sp_rename 'dbo.Operations.note', 'Note', 'COLUMN';

    EXEC sp_rename 'dbo.Options.name', 'Name', 'COLUMN';
    EXEC sp_rename 'dbo.Options.user_id', 'UserId', 'COLUMN';
    EXEC sp_rename 'dbo.Options.type_id', 'TypeId', 'COLUMN';
    EXEC sp_rename 'dbo.Options.value', 'Value', 'COLUMN';

    EXEC sp_rename 'dbo.PassReadings.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.PassReadings.acknowledge', 'Acknowledge', 'COLUMN';
    EXEC sp_rename 'dbo.PassReadings.date1', 'Date1', 'COLUMN';
    EXEC sp_rename 'dbo.PassReadings.date2', 'Date2', 'COLUMN';
    EXEC sp_rename 'dbo.PassReadings.date3', 'Date3', 'COLUMN';
    EXEC sp_rename 'dbo.PassReadings.date4', 'Date4', 'COLUMN';
    EXEC sp_rename 'dbo.PassReadings.sender', 'Sender', 'COLUMN';
    EXEC sp_rename 'dbo.PassReadings.senders_listener_port', 'SendersListenerPort', 'COLUMN';
    EXEC sp_rename 'dbo.PassReadings.value', 'Value', 'COLUMN';

    EXEC sp_rename 'dbo.Permissions.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Permissions.operation_id', 'OperationId', 'COLUMN';
    EXEC sp_rename 'dbo.Permissions.group_id', 'GroupId', 'COLUMN';
    EXEC sp_rename 'dbo.Permissions.user_event', 'UserEvent', 'COLUMN';

    EXEC sp_rename 'dbo.ReadingGroups.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.ReadingGroups.name', 'Name', 'COLUMN';
    EXEC sp_rename 'dbo.ReadingGroups.description', 'Description', 'COLUMN';

    EXEC sp_rename 'dbo.RgCfRule.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.RgCfRule.RG_ID', 'RgId', 'COLUMN';
    EXEC sp_rename 'dbo.RgCfRule.R_ID', 'RId', 'COLUMN';

    EXEC sp_rename 'dbo.Rules.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Rules.name', 'Name', 'COLUMN';
    EXEC sp_rename 'dbo.Rules.rulestr', 'RuleStr', 'COLUMN';

    EXEC sp_rename 'dbo.SavedImages.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.SavedImages.camera_id', 'CameraId', 'COLUMN';
    EXEC sp_rename 'dbo.SavedImages.event_date', 'EventDate', 'COLUMN';
    EXEC sp_rename 'dbo.SavedImages.img', 'Image', 'COLUMN';
    EXEC sp_rename 'dbo.SavedImages.store_date', 'StoreDate', 'COLUMN';

    EXEC sp_rename 'dbo.Sequences.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Sequences.active', 'Active', 'COLUMN';
    EXEC sp_rename 'dbo.Sequences.name', 'Name', 'COLUMN';
    EXEC sp_rename 'dbo.Sequences.priority', 'Priority', 'COLUMN';

    EXEC sp_rename 'dbo.Servers.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Servers.iporhost', 'IpOrHost', 'COLUMN';
    EXEC sp_rename 'dbo.Servers.displayed_name', 'DisplayedName', 'COLUMN';
    EXEC sp_rename 'dbo.Servers.dongle_sn', 'DongleSn', 'COLUMN';
    EXEC sp_rename 'dbo.Servers.sziltech_sn', 'SziltechSn', 'COLUMN';
    EXEC sp_rename 'dbo.Servers.mac_address', 'MacAddress', 'COLUMN';
    EXEC sp_rename 'dbo.Servers.start_in_motion_popup', 'StartInMotionPopup', 'COLUMN';
    EXEC sp_rename 'dbo.Servers.username', 'Username', 'COLUMN';
    EXEC sp_rename 'dbo.Servers.password', 'Password', 'COLUMN';
    EXEC sp_rename 'dbo.Servers.win_user', 'WinUser', 'COLUMN';
    EXEC sp_rename 'dbo.Servers.win_pass', 'WinPass', 'COLUMN';

    EXEC sp_rename 'dbo.ServerStates.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.ServerStates.server_id', 'ServerId', 'COLUMN';
    EXEC sp_rename 'dbo.ServerStates.last_state', 'LastState', 'COLUMN';

    EXEC sp_rename 'dbo.Templates.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Templates.template_name', 'TemplateName', 'COLUMN';

    EXEC sp_rename 'dbo.Users.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.Users.address', 'Address', 'COLUMN';
    EXEC sp_rename 'dbo.Users.barcode', 'Barcode', 'COLUMN';
    EXEC sp_rename 'dbo.Users.carsign', 'LicensePlate', 'COLUMN';
    EXEC sp_rename 'dbo.Users.email', 'Email', 'COLUMN';
    EXEC sp_rename 'dbo.Users.fullname', 'Fullname', 'COLUMN';
    EXEC sp_rename 'dbo.Users.other_information', 'OtherInformation', 'COLUMN';
    EXEC sp_rename 'dbo.Users.picture', 'Image', 'COLUMN';
    EXEC sp_rename 'dbo.Users.needed_secondary_logon_Priority', 'NeededSecondaryLogonPriority', 'COLUMN';
    EXEC sp_rename 'dbo.Users.secondary_logon_priority', 'SecondaryLogonPriority', 'COLUMN';
    EXEC sp_rename 'dbo.Users.telephone', 'Phone', 'COLUMN';
    EXEC sp_rename 'dbo.Users.username', 'Username', 'COLUMN';
    EXEC sp_rename 'dbo.Users.password', 'Password', 'COLUMN';

    EXEC sp_rename 'dbo.UserEvents.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.UserEvents.name', 'Name', 'COLUMN';
    EXEC sp_rename 'dbo.UserEvents.note', 'Note', 'COLUMN';

    EXEC sp_rename 'dbo.UsersInGroups.ID', 'Id', 'COLUMN';
    EXEC sp_rename 'dbo.UsersInGroups.user_id', 'UserId', 'COLUMN';
    EXEC sp_rename 'dbo.UsersInGroups.group_id', 'GroupId', 'COLUMN';

END;