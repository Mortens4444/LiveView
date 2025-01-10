IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Maps]') AND name = 'MapImage' AND is_nullable = 0)
BEGIN
    ALTER TABLE Maps ALTER COLUMN MapImage VARBINARY(MAX) NULL;
END