UPDATE Grid_cameralist
SET 
    grid_id = @GridId,
    camera_id = @CameraId,
    init_row = @InitRow,
    init_col = @InitCol,
    end_row = @EndRow,
    end_col = @EndCol,
    osd = @Osd,
    frame = @Frame,
    [left] = @Left,
    [top] = @Top,
    width = @Width,
    height = @Height,
    checksum = @Checksum,
    ptz = @Ptz,
    motion_save_images = @MotionSaveImages,
    motion_number_of_photos = @MotionNumberOfPhotos,
    motion_value = @MotionValue,
    csr_save_images = @CsrSaveImages,
    csr_number_of_photos = @CsrNumberOfPhotos,
    csr_value = @CsrValue,
    show_date_time = @ShowDateTime
WHERE ID = @Id;