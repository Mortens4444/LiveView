DELETE FROM Permissions WHERE GroupId = @GroupId AND UserEventId = @UserEventId;
DELETE FROM CameraPermissions WHERE GroupId = @GroupId AND UserEventId = @UserEventId;