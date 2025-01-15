UPDATE Groups
SET 
    Name = @Name,
    OtherInformation = @OtherInformation
WHERE Id = @Id;
