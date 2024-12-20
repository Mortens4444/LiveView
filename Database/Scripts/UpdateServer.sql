UPDATE Servers SET
	IpOrHost = @IpAddress,
	Username = @Username,
	Password = @Password,
	DisplayedName = @Hostname,
	DongleSn = @DongleSn,
	SziltechSn = @SerialNumber,
	MacAddress = @MacAddress
WHERE Id = @Id;