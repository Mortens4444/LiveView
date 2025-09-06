UPDATE InputOutputPortRules SET
    OperationId = @OperationId,
    UserEventId = @UserEventId,
    DeviceId = @DeviceId,
    PortNumber = @PortNumber,
    ZeroSignalled = @ZeroSignalled
WHERE Id = @Id;