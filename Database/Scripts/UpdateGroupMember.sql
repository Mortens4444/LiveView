UPDATE GroupMembers SET
	GroupId = @GroupId,
	UserId = @UserId
WHERE Id = @Id;