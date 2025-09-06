UPDATE InputOutputPorts SET
    DeviceId = @DeviceId,
    PortNum = @PortNum,
    Name = @Name,
    FriendlyName = @FriendlyName,
    Direction = @Direction,
    State = @State,
    MinTriggerTime = @MinTriggerTime,
    MaxCount = @MaxCount
WHERE Id = @Id;