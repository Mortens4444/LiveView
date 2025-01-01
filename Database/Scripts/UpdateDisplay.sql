UPDATE Displays
SET 
    Fullscreen = @Fullscreen,
    CanShowSequence = @CanShowSequence,
    CanShowFullscreen = @CanShowFullscreen,
    SziltechId = @SziltechId
WHERE Id = @Id;