UPDATE UserEvents SET
	Name = @Name,
	Note = @Note
WHERE Id = @Id;