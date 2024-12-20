INSERT INTO Logs
	(Date, UserId, OperationId, EventId, LanguageElementId, OtherInformation)
VALUES
	(@Date, @UserId, @OperationId, @EventId, @LanguageElementId, @OtherInformation);
