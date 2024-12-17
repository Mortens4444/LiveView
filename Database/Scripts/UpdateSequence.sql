UPDATE Sequences
SET 
    name = @Name,
    active = @Active,
    priority = @Priority,
    checksum = @Checksum
WHERE ID = @Id;
