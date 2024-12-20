SELECT IpAddress, FullscreenMode, StreamId, c.Username, c.Password, Guid, CameraName, IpOrHost, s.Username, s.Password, s.Id as ServerId
FROM Cameras as c LEFT JOIN Servers as s ON c.ServerId = s.Id;