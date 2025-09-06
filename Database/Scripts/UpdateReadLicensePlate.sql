UPDATE ReadLicensePlates SET
	LicensePlate = @LicensePlate,
	ReadDate = @ReadDate,
	CameraId = @CameraId,
	ImageId = @ImageId,
	Confidence = @Confidence
WHERE Id = @Id;