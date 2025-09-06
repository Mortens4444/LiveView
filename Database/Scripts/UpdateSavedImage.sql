UPDATE SavedImages
SET 
	CameraId = @CameraId,
	EventDate = @EventDate,
	StoreDate = @StoreDate,
	Image = @Image
WHERE Id = @Id;
