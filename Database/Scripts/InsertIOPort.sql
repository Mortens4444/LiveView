INSERT INTO IOPorts
	(DeviceId, PortNum, Name, FriendlyName, Direction, State, MinTriggerTime, MaxCount)
VALUES
	(@DeviceId, @PortNum, @Name, @FriendlyName, @Direction, @State, @MinTriggerTime, @MaxCount);
