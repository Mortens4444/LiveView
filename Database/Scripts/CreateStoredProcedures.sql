GO

CREATE PROCEDURE Select_All_IOPorts_Rules
AS
BEGIN
	SELECT * FROM IOPorts_Rules ORDER BY device_id, port_num, operation_id, event_id;
END;

GO

CREATE PROCEDURE Insert_IOPorts_Rule
	@device_id BIGINT,
	@port_number INT,
	@operation_id BIGINT = NULL,
	@event_id BIGINT = NULL,
	@zero_signaled BIT
AS
BEGIN
	INSERT INTO IOPorts_Rules (device_id, port_num, operation_id, event_id, zero_signaled)
	VALUES (@device_id, @port_number, @operation_id, @event_id, @zero_signaled);
END;

GO

CREATE PROCEDURE Delete_IOPorts_Rule
	@ID BIGINT
AS
BEGIN
	DELETE FROM IOPorts_Rules WHERE ID = @ID;
END;

GO

CREATE PROCEDURE Select_All_IOPorts_Logs
AS
BEGIN
	SELECT * FROM IOPorts_Logs ORDER BY date DESC;
END;

GO

CREATE PROCEDURE Insert_IOPort_LogEntry
	@device_id int,
	@port_number int,
	@state int,
	@date datetime,
	@user_id bigint,
	@note nvarchar(max)
AS
BEGIN
	INSERT INTO IOPorts_Logs (device_id, port_num, state, date, user_id, note)
	VALUES (@device_id, @port_number, @state, @date, @user_id, @note);
END;

GO

CREATE PROCEDURE Get_IOPort_Change_Count
	@device_id int,
	@port_number int,
	@D1 datetime,
	@D2 datetime
AS
BEGIN
	SELECT COUNT(ID) FROM IOPorts_Logs WHERE (device_id = @device_id) AND (port_num = @port_number) AND date BETWEEN @D1 AND @D2;
END;

GO

CREATE PROCEDURE Select_All_IOPorts
AS
BEGIN
	SELECT * FROM IOPorts ORDER BY device_id, port_num;
END;

GO

CREATE PROCEDURE Insert_IOPort
	@device_id int,
	@port_number int,
	@name nvarchar(255),
	@friendly_name nvarchar(255),
	@direction int,
	@state int,
	@min_trigger_time int,
	@max_count int
AS
BEGIN
	INSERT INTO IOPorts (device_id, port_num, name, friendly_name, direction, state, min_trigger_time, max_count)
	VALUES (@device_id, @port_number, @name, @friendly_name, @direction, @state, @min_trigger_time, @max_count);
END;

GO

CREATE PROCEDURE Update_IOPort
	@friendly_name nvarchar(255),
	@max_count int,
	@min_trigger_time int,
	@device_id int,
	@port_number int
AS
BEGIN
	UPDATE IOPorts SET friendly_name = @friendly_name, max_count = @max_count, min_trigger_time = @min_trigger_time
	WHERE (device_id = @device_id) AND (port_num = @port_number);
END;

GO

CREATE PROCEDURE Update_IOPort_State
	@name nvarchar(255),
	@direction int,
	@state int,
	@device_id int,
	@port_number int
AS
BEGIN
	UPDATE IOPorts SET name = @name, direction = @direction, state = @state
	WHERE (device_id = @device_id) AND (port_num = @port_number);
END;

GO