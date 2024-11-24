SELECT COALESCE(
    (SELECT CONCAT(preset_name, ' - ', s.name) AS name
     FROM CameraPresets AS cp
     JOIN Cameras AS c ON cp.camera_id = c.ID
     JOIN Servers AS s ON c.serverid = s.ID
     WHERE c.guid = @C AND cp.preset = @preset_value),
    (SELECT CONCAT(pattern_name, ' - ', s.name) AS name
     FROM CameraPatterns AS cp
     JOIN Cameras AS c ON cp.camera_id = c.ID
     JOIN Servers AS s ON c.serverid = s.ID
     WHERE c.guid = @C AND cp.pattern = @pattern_value)
) AS name;

--SELECT COALESCE(
--    (SELECT preset_name 
--     FROM CameraPresets 
--     WHERE camera_id = (SELECT ID FROM Cameras WHERE guid = @C) 
--       AND preset = @preset_value),
--    (SELECT pattern_name 
--     FROM CameraPatterns 
--     WHERE camera_id = (SELECT ID FROM Cameras WHERE guid = @C) 
--       AND pattern = @pattern_value)
--) AS name;