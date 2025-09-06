UPDATE DeleteReadingGroupRules SET
	RuleId = @RuleId,
	ReadingGroupId = @ReadingGroupId
WHERE Id = @Id;