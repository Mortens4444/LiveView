UPDATE Sequences
SET 
    Name = @Name,
    Active = @Active,
    Priority = @Priority
WHERE Id = @Id;
