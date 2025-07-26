INSERT INTO Credentials (EncryptedUsername, EncryptedPassword, CredentialType)
VALUES (@EncryptedUsername, @EncryptedPassword, 2);

DECLARE @CredentialsId INT = SCOPE_IDENTITY();

INSERT INTO Cameras
    (VideoServerId, CameraName, Guid, Priority, RecorderIndex, CameraCredentialsId, PermissionCamera)
SELECT
    @VideoServerId, @CameraName, @Guid, 0, @RecorderIndex, @CredentialsId,
    COALESCE((
        SELECT MIN(t1.PermissionCamera + 1)
        FROM Cameras t1
        LEFT JOIN Cameras t2 ON t1.PermissionCamera + 1 = t2.PermissionCamera
        WHERE t2.PermissionCamera IS NULL
    ), 1);