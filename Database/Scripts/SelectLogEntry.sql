SELECT * FROM Logs
WHERE
    (LogType = @LogType OR @LogType = 0) -- Filter by LogType if not 'Any'
    AND Date BETWEEN @From AND @To      -- Filter by date range
    AND (@MessagePart IS NULL OR Message LIKE '%' + @MessagePart + '%') -- Filter by message part
    AND (@OtherInformationPart IS NULL OR OtherInformation LIKE '%' + @OtherInformationPart + '%') -- Filter by other information
    AND (@UserId = 0 OR UserId = @UserId) -- Filter by UserId if not default
ORDER BY 
    Date DESC
OFFSET @Offset ROWS FETCH NEXT @MaxRows ROWS ONLY; -- Pagination with OFFSET and FETCH