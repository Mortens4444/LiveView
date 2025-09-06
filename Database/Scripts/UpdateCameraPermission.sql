UPDATE CameraPermissions SET
	GroupId = @GroupId,
	CameraId = @CameraId,
	UserEventId = @UserEventId
WHERE Id = @Id;