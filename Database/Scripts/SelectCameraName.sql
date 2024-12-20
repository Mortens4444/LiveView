SELECT COALESCE(
    (SELECT CONCAT(PresetName, ' - ', s.Name) AS Name
     FROM CameraPresets AS cp
     JOIN Cameras AS c ON cp.CameraId = c.Id
     JOIN Servers AS s ON c.ServerId = s.Id
     WHERE c.Guid = @Guid AND cp.Preset = @PresetValue),
    (SELECT CONCAT(PatternName, ' - ', s.Name) AS Name
     FROM CameraPatterns AS cp
     JOIN Cameras AS c ON cp.CameraId = c.Id
     JOIN Servers AS s ON c.ServerId = s.Id
     WHERE c.Guid = @Guid AND cp.Pattern = @PatternValue)
) AS name;

--SELECT COALESCE(
--    (SELECT PresetName 
--     FROM CameraPresets 
--     WHERE CameraId = (SELECT Id FROM Cameras WHERE Guid = @Guid) 
--       AND Preset = @PresetValue),
--    (SELECT PatternName 
--     FROM CameraPatterns 
--     WHERE CameraId = (SELECT Id FROM Cameras WHERE Guid = @Guid) 
--       AND Pattern = @PatternValue)
--) AS name;