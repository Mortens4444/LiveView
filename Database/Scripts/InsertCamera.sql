INSERT INTO Cameras
    (ServerId, CameraName, Guid, Priority, RecorderIndex, PermissionCamera)
SELECT
    @ServerId, @CameraName, @Guid, 0, @RecorderIndex,
    COALESCE((
        SELECT MIN(t1.PermissionCamera + 1)
        FROM Cameras t1
        LEFT JOIN Cameras t2 ON t1.PermissionCamera + 1 = t2.PermissionCamera
        WHERE t2.PermissionCamera IS NULL
    ), 1);