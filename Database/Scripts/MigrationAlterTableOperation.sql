ALTER TABLE Operations DROP COLUMN LanguageElementId, Note;

ALTER TABLE Operations ADD
    PermissionGroup NVARCHAR(255) NOT NULL,
    PermissionValue NVARCHAR(255) NOT NULL;