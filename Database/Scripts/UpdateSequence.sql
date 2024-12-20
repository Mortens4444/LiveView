UPDATE Sequences
SET 
    Name = @Name,
    Active = @Active,
    Priority = @Priority,
    Checksum = @Checksum
WHERE Id = @Id;
