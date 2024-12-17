SELECT ID as Id, grid_id as GridId, camera_id as CameraId, init_row as InitRow, init_col as InitCol, end_row as EndRow,
    end_col as EndCol, osd as Osd, frame as Frame, [left] as [Left], [top]  as [Top],
    width as Width, height as Heght, checksum as Checksum, ptz as Ptz,
    motion_save_images as MotionSaveImages, motion_number_of_photos as MotionNumberOfPhotos, motion_value as MotionValue,
    csr_save_images as CsrSaveImages, csr_number_of_photos as CsrNumberOfPhotos, csr_value as CsrValue, show_date_time as ShowDateTime
FROM Grid_cameralist;