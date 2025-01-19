SELECT Id INTO #TempObjectsInMaps FROM ObjectsInMaps WHERE MapId = @Id;
DELETE FROM ObjectsInMaps WHERE MapId = @Id;
DELETE FROM MapObject WHERE Id IN (SELECT Id FROM #TempObjectsInMaps);
DELETE FROM MapObjects WHERE Id = @Id;