SELECT c.*, s.DisplayedName AS ServerDisplayName
FROM Cameras AS c
JOIN CameraPermissions AS cp ON c.Id = cp.CameraId
LEFT JOIN Servers AS s ON c.ServerId = s.Id
WHERE cp.GroupId = @GroupId AND cp.UserEventId = @UserEventId;