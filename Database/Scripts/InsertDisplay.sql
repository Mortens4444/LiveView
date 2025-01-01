IF NOT EXISTS (SELECT * FROM Displays WHERE Id = @Id)
BEGIN

    INSERT INTO Displays
        (Id, X, Y, Width, Height, MaxWidth, MaxHeight, DeviceName, SziltechId, 
         MonitorName, AdapterName, IsPrimary, Removable, AttachedToDesktop, 
         Fullscreen, CanShowSequence, CanShowFullscreen)
    VALUES
        (@Id, @X, @Y, @Width, @Height, @MaxWidth, @MaxHeight, @DeviceName, @SziltechId, 
         @MonitorName, @AdapterName, @IsPrimary, @Removable, @AttachedToDesktop, 
         @Fullscreen, @CanShowSequence, @CanShowFullscreen);

END
ELSE
BEGIN
    UPDATE Displays
    SET 
        SziltechId = @SziltechId,
        MonitorName = @MonitorName,
        AdapterName = @AdapterName,
        X = @X,
        Y = @Y,
        Width = @Width,
        Height = @Height,
        MaxWidth = @MaxWidth,
        MaxHeight = @MaxHeight,
        DeviceName = @DeviceName,
        IsPrimary = @IsPrimary,
        Removable = @Removable,
        AttachedToDesktop = @AttachedToDesktop
    WHERE Id = @Id;
END