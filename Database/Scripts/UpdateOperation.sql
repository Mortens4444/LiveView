UPDATE Operations SET
	PermissionGroup = @PermissionGroup,
	PermissionValue = @PermissionValue
WHERE Id = @Id;