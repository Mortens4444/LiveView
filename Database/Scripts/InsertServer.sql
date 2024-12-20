INSERT INTO Servers
	(StartInMotionPopup, IpOrHost, Username, Password, DisplayedName, DongleSn, SziltechSn, MacAddress)
VALUES
	(@StartInMotionPopup, @IpAddress, @Username, @Password, @Hostname, @DongleSn, @SerialNumber, @MacAddress);