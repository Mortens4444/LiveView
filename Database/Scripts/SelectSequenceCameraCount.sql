SELECT COUNT(gc.GridId) FROM GridCameras gc
INNER JOIN SequenceGrids sg ON gc.GridId = sg.GridId
WHERE sg.SequenceId = @SequenceId;