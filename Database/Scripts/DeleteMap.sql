SELECT ActionObjectId INTO #TempActionObjectIds FROM MapActionObjects WHERE MapId = @Id;

DELETE FROM MapActionObjects WHERE MapId = @Id;

DELETE AO FROM ActionObjects AO
WHERE AO.Id IN (SELECT ActionObjectId FROM #TempActionObjectIds)
  AND NOT EXISTS (SELECT 1 FROM MapActionObjects m WHERE m.ActionObjectId = AO.Id);

DELETE FROM Maps WHERE Id = @Id;

DROP TABLE #TempActionObjectIds;