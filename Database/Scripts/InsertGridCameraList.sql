INSERT INTO GridCameralist
    (GridId, CameraId, InitRow, InitCol, EndRow, EndCol, Osd, Frame, [Left], [Top], Width, Height, Ptz,
    MotionSaveImages, MotionNumberOfPhotos, MotionValue, CsrSaveImages, CsrNumberOfPhotos, CsrValue, ShowDateTime)
VALUES
    (@GridId, @CameraId, @InitRow, @InitCol, @EndRow, @EndCol, @Osd, @Frame, @Left, @Top, @Width, @Height, @Ptz,
    @MotionSaveImages, @MotionNumberOfPhotos, @MotionValue, @CsrSaveImages, @CsrNumberOfPhotos, @CsrValue, @ShowDateTime);