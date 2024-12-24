UPDATE GridCameralist
SET 
    GridId = @GridId,
    CameraId = @CameraId,
    InitRow = @InitRow,
    InitCol = @InitCol,
    EndRow = @EndRow,
    EndCol = @EndCol,
    Osd = @Osd,
    Frame = @Frame,
    [Left] = @Left,
    [Top] = @Top,
    Width = @Width,
    Height = @Height,
    Ptz = @Ptz,
    MotionSaveImages = @MotionSaveImages,
    MotionNumberOfPhotos = @MotionNumberOfPhotos,
    MotionValue = @MotionValue,
    CsrSaveImages = @CsrSaveImages,
    CsrNumberOfPhotos = @CsrNumberOfPhotos,
    CsrValue = @CsrValue,
    ShowDateTime = @ShowDateTime
WHERE Id = @Id;