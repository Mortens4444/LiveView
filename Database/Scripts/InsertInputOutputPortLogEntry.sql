INSERT INTO InputOutputPortLogs
    (UserId,
    DeviceId,
    Date,
    Note,
    PortNumber,
    State)
VALUES
    (@UserId,
    @DeviceId,
    @Date,
    @Note,
    @PortNumber,
    @State)