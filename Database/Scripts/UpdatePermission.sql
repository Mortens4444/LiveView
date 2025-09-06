UPDATE Permissions SET
	GroupId = @GroupId,
	OperationId = @OperationId,
	UserEventId = @UserEventId
WHERE Id = @Id;