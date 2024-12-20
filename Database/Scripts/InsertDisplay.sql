IF NOT EXISTS (SELECT * FROM Displays WHERE PnpDeviceId = @PnpDeviceId)
BEGIN
	INSERT INTO Displays
		(PnpDeviceId, ShownName, FullscreenDisplay, CanShowSequence, CanShowFullscreen)
	VALUES
		(@PnpDeviceId, @ShownName, 'False', 'True', 'True');
END