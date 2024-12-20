UPDATE Groups
SET 
    Name = @Name,
    OtherInformation = @OtherInformation,
    ParentGroupId = @ParentGroupId,
    Checksum = @Checksum
WHERE Id = @Id;
