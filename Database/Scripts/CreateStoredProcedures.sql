GO

CREATE PROCEDURE SelectAllInputOutputPortRules
AS
BEGIN
	SELECT * FROM InputOutputPortRules ORDER BY DeviceId, PortNumber, OperationId, UserEventId;
END;

GO

CREATE PROCEDURE InsertInputOutputPortRule
	@DeviceId INT,
	@PortNumber INT,
	@OperationId INT = NULL,
	@UserEventId INT = NULL,
	@ZeroSignalled BIT
AS
BEGIN
	INSERT INTO InputOutputPortRules (DeviceId, PortNumber, OperationId, EventId, ZeroSignalled)
	VALUES (@DeviceId, @PortNumber, @OperationId, @EventId, @ZeroSignalled);
END;

GO

CREATE PROCEDURE DeleteInputOutputPortRule
	@Id INT
AS
BEGIN
	DELETE FROM InputOutputPortRules WHERE Id = @Id;
END;

GO

CREATE PROCEDURE SelectAllInputOutputPortLogs
AS
BEGIN
	SELECT * FROM InputOutputPortLogs ORDER BY date DESC;
END;

GO

CREATE PROCEDURE InsertInputOutputPortLogEntry
	@DeviceId INT,
	@PortNumber INT,
	@State INT,
	@Date DATETIME,
	@UserId INT,
	@Note NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO InputOutputPortLogs (DeviceId, PortNumber, State, Date, UserId, Note)
	VALUES (@DeviceId, @PortNumber, @State, @Date, @UserId, @Note);
END;

GO

CREATE PROCEDURE GetInputOutputPortChangeCount
	@DeviceId INT,
	@PortNumber INT,
	@D1 DATETIME,
	@D2 DATETIME
AS
BEGIN
	SELECT COUNT(ID) FROM InputOutputPortLogs WHERE (DeviceId = @DeviceId) AND (PortNumber = @PortNumber) AND date BETWEEN @D1 AND @D2;
END;

GO

CREATE PROCEDURE SelectAllInputOutputPorts
AS
BEGIN
	SELECT * FROM InputOutputPorts ORDER BY DeviceId, PortNumber;
END;

GO

CREATE PROCEDURE InsertInputOutputPort
	@DeviceId INT,
	@PortNumber INT,
	@Name NVARCHAR(255),
	@FriendlyName NVARCHAR(255),
	@Direction INT,
	@State INT,
	@MinTriggerTime INT,
	@MaxCount INT
AS
BEGIN
	INSERT INTO InputOutputPorts (DeviceId, PortNumber, Name, FriendlyName, Direction, State, MinTriggerTime, MaxCount)
	VALUES (@DeviceId, @PortNumber, @Name, @FriendlyName, @Direction, @State, @MinTriggerTime, @MaxCount);
END;

GO

CREATE PROCEDURE UpdateInputOutputPort
	@FriendlyName NVARCHAR(255),
	@MaxCount INT,
	@MinTriggerTime INT,
	@DeviceId INT,
	@PortNumber INT
AS
BEGIN
	UPDATE InputOutputPorts SET FriendlyName = @FriendlyName, MaxCount = @MaxCount, MinTriggerTime = @MinTriggerTime
	WHERE (DeviceId = @DeviceId) AND (PortNumber = @PortNumber);
END;

GO

CREATE PROCEDURE UpdateInputOutputPortState
	@Name NVARCHAR(255),
	@Direction INT,
	@State INT,
	@DeviceId INT,
	@PortNumber INT
AS
BEGIN
	UPDATE InputOutputPorts SET Name = @Name, Direction = @Direction, State = @State
	WHERE (DeviceId = @DeviceId) AND (PortNumber = @PortNumber);
END;

GO