SELECT c.*, s.DisplayedName as ServerDisplayName, s.Username as ServerUsername, s.Password as ServerPassword, s.Id as ServerId
FROM Cameras as c LEFT JOIN Servers as s ON c.ServerId = s.Id;