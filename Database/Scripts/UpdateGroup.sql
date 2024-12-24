UPDATE Groups
SET 
    Name = @Name,
    OtherInformation = @OtherInformation,
    ParentGroupId = @ParentGroupId
WHERE Id = @Id;
