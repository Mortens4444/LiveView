INSERT INTO Grid_cameralist (grid_id, camera_id, init_row, init_col, end_row, end_col, osd, frame, [left], [top], width, height, checksum, ptz, motion_save_images, 
    motion_number_of_photos, motion_value, csr_save_images, csr_number_of_photos, csr_value, show_date_time)
VALUES (@GridId, @CameraId, @InitRow, @InitCol, @EndRow, @EndCol, @Osd, @Frame, @Left, @Top, @Width, @Height, @Checksum, @Ptz, @MotionSaveImages, 
    @MotionNumberOfPhotos, @MotionValue, @CsrSaveImages, @CsrNumberOfPhotos, @CsrValue, @ShowDateTime);