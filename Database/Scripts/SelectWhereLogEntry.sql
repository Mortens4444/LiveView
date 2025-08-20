SELECT * FROM Logs
WHERE
    Date BETWEEN @From AND @To
        AND (
        @LogType = 0 
        OR (@LogType = 1 AND OperationId IS NOT NULL) 
        OR (@LogType = 2 AND UserEventId IS NOT NULL) 
        OR (@LogType = 3 AND OperationId IS NULL AND UserEventId IS NULL)
    )
    AND (@OtherInformationPart IS NULL OR OtherInformation LIKE '%' + @OtherInformationPart + '%')
    AND (@UserId = 0 OR UserId = @UserId)
ORDER BY 
    Date DESC
OFFSET @Offset ROWS FETCH NEXT @MaxRows ROWS ONLY;