SELECT c.Id, c.CameraName, c.Guid, c.VideoServerId FROM Cameras as c, VideoServers as s
WHERE c.VideoServerId = s.Id
ORDER BY s.Hostname, c.CameraName;