INSERT INTO GridCameras
    (GridId, CameraId, InitRow, InitCol, EndRow, EndCol, Osd, Frame, [Left], [Top], Width, Height, Ptz, MotionSaveImages,
    MotionNumberOfPhotos, MotionValue, CsrSaveImages, CsrNumberOfPhotos, CsrValue, ShowDateTime, CameraMode)
VALUES
    (@GridId, @CameraId, @InitRow, @InitCol, @EndRow, @EndCol, @Osd, @Frame, @Left, @Top, @Width, @Height, @Ptz, @MotionSaveImages,
    @MotionNumberOfPhotos, @MotionValue, @CsrSaveImages, @CsrNumberOfPhotos, @CsrValue, @ShowDateTime, @CameraMode);