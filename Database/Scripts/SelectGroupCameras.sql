SELECT c.*, s.Hostname AS ServerDisplayName FROM Cameras AS c
JOIN CameraPermissions AS cp ON c.Id = cp.CameraId
LEFT JOIN VideoServers AS s ON c.VideoServerId = s.Id
WHERE cp.GroupId = @GroupId AND cp.UserEventId = @UserEventId;