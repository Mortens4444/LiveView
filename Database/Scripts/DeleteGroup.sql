UPDATE Users 
    SET NeededSecondaryLogonPriority = 100 
WHERE Id IN (
    SELECT UserId 
    FROM GroupMembers 
    WHERE GroupId = @Id 
       OR GroupId IN (SELECT Id FROM Groups WHERE ParentGroupId = @Id)
);

DELETE FROM Groups WHERE Id = @Id OR ParentGroupId = @Id;