﻿--IF EXISTS (SELECT * FROM sys.columns
--           WHERE object_id = OBJECT_ID(N'[dbo].[Cameras]') AND name = '')
--BEGIN
--    ALTER TABLE BSCharChanger ALTER COLUMN Id INT;
--    ALTER TABLE BSOptions ALTER COLUMN Id INT;
--    ALTER TABLE CameraPermissions ALTER COLUMN Id INT;
--END;