SELECT COUNT(gc.GridId)
FROM GridCameras gc
INNER JOIN GridsInSequences gs ON gc.GridId = gs.GridId
WHERE gs.SequenceId = @SequenceId;