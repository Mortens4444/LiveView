UPDATE CameraFunction SET
    CameraId = @CameraId,
    FunctionId = @FunctionId,
    FunctionCallback = @FunctionCallback
WHERE Id = @Id;