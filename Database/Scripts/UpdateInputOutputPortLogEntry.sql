UPDATE InputOutputPortLogs SET
    UserId = @UserId,
    DeviceId = @DeviceId,
    Date = @Date,
    Note = @Note,
    PortNumber = @PortNumber,
    State = @State
WHERE Id = @Id;