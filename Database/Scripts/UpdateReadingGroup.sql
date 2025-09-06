UPDATE ReadingGroups SET
	Name = @Name,
	Description = @Description
WHERE Id = @Id;