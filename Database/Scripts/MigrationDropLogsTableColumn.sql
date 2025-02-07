IF EXISTS (SELECT * FROM sys.columns
           WHERE object_id = OBJECT_ID(N'[dbo].[Logs]') AND name = 'LanguageElementId')
BEGIN
    ALTER TABLE Logs DROP COLUMN LanguageElementId;
END;