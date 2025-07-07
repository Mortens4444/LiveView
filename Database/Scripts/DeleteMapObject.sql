SELECT Id INTO #TempMapActionObjects FROM MapActionObjects WHERE MapId = @Id;
DELETE FROM MapActionObjects WHERE MapId = @Id;
DELETE FROM MapObject WHERE Id IN (SELECT Id FROM #TempMapActionObjects);
DELETE FROM ActionObjects WHERE Id = @Id;