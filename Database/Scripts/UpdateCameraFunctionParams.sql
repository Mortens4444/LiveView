UPDATE CameraFunctionParams SET
    CameraFunctionId = @CameraFunctionId,
    ParamIndex = @ParamIndex,
    ParamValue = @ParamValue
WHERE Id = @Id;