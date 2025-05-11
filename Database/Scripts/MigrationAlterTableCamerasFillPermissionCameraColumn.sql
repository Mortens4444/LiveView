WITH OrderedCameras AS
(
    SELECT Id, ROW_NUMBER() OVER (ORDER BY Id) - 1 AS RowIndex FROM Cameras WHERE PermissionCamera = 0 OR PermissionCamera IS NULL
)
UPDATE C SET PermissionCamera = O.RowIndex FROM Cameras C JOIN OrderedCameras O ON C.Id = O.Id;