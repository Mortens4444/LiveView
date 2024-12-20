UPDATE IOPorts
SET 
    DeviceId = @DeviceId,
    PortNum = @PortNum,
    Name = @Name,
    FriendlyName = @FriendlyName,
    Direction = @Direction,
    State = @State,
    MinTriggerTime = @MinTriggerTime,
    MaxCount = @MaxCount,
    Checksum = @Checksum
WHERE Id = @Id;
