SELECT Id, GridId, CameraId, InitRow, InitCol, EndRow, EndCol, Osd, Frame, [Left], [Top], Width, Height, Ptz,
    MotionSaveImages, MotionNumberOfPhotos, MotionValue, CsrSaveImages, CsrNumberOfPhotos, CsrValue, ShowDateTime
FROM GridCameralist WHERE GridId = @GridId;