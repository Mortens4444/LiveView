DELETE FROM Permissions WHERE GroupId = @GroupId AND UserEvent = @UserEventId;
DELETE FROM CameraPermissions WHERE GroupId = @GroupId AND UserEvent = @UserEventId;