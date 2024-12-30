SELECT Id, IpOrHost AS IpAddress, Username, Password, MacAddress, DisplayedName AS Hostname, DongleSn, SziltechSn AS SerialNumber, StartInMotionPopup FROM Servers WHERE Id = @Id;
