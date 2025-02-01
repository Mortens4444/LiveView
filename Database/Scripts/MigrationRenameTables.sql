IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pass_readings]') AND type = N'U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PassReadings]') AND type = N'U')
    BEGIN
        EXEC sp_rename N'[dbo].[Pass_readings]', N'PassReadings';
    END
END;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IOPorts_Rules]') AND type = N'U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IOPortsRules]') AND type = N'U')
    BEGIN
        EXEC sp_rename N'[dbo].[IOPorts_Rules]', N'IOPortsRules';
    END
END;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IOPorts_Logs]') AND type = N'U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IOPortsLogs]') AND type = N'U')
    BEGIN
        EXEC sp_rename N'[dbo].[IOPorts_Logs]', N'IOPortsLogs';
    END
END;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grid_cameralist]') AND type = N'U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GridCameralist]') AND type = N'U')
    BEGIN
        EXEC sp_rename N'[dbo].[Grid_cameralist]', N'GridCameralist';
    END
END;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Monitors]') AND type = N'U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Displays]') AND type = N'U')
    BEGIN
        EXEC sp_rename N'[dbo].[Monitors]', N'Displays';
    END
END;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pictures]') AND type = N'U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SavedImages]') AND type = N'U')
    BEGIN
        EXEC sp_rename N'[dbo].[Pictures]', N'SavedImages';
    END
END;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rights]') AND type = N'U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permissions]') AND type = N'U')
    BEGIN
        EXEC sp_rename N'[dbo].[Rights]', N'Permissions';
    END
END;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RightsOnCameras]') AND type = N'U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CameraPermissions]') AND type = N'U')
    BEGIN
        EXEC sp_rename N'[dbo].[RightsOnCameras]', N'CameraPermissions';
    END
END;
