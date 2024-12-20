INSERT INTO Databases
	(Name, Path, IsExists, IsActive, IsArchived, Filename)
VALUES
	(@Name, @Path, 'True', 'False', 'False', @Filename)
