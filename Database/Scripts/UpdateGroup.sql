UPDATE Groups
SET 
    name = @Name,
    other_information = @OtherInformation,
    parent_group_id = @ParentGroupId,
    checksum = @Checksum
WHERE ID = @Id;
