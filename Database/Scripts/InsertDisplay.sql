IF NOT EXISTS (SELECT * FROM Displays WHERE PnpDeviceId = @PnpDeviceId)
BEGIN
	INSERT INTO Displays
		(Id, SziltechId, MonitorName, AdapterName, Fullscreen, CanShowSequence, CanShowFullscreen)
	VALUES
		(@Id, @SziltechId, @MonitorName, @AdapterName, 'False', 'True', 'True');
END