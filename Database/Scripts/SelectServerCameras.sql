SELECT c.Id, c.CameraName, c.Guid, c.ServerId FROM Cameras as c, Servers as s
WHERE c.ServerId = s.Id
ORDER BY s.DisplayedName, c.CameraName