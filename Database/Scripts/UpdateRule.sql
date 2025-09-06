UPDATE Rules SET
	Name = @Name,
	RuleStr = @RuleStr
WHERE Id = @Id;