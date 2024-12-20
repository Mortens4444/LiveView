UPDATE Databases SET
	IsActive = @IsActive,
	IsArchived = @IsArchived,
	Filename = @Filename
WHERE Name = @Name