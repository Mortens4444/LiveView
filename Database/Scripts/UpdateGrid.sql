UPDATE Grids
SET 
    Rows = @Rows,
    Columns = @Columns,
    PixelsFromRight = @PixelsFromRight,
    PixelsFromBottom = @PixelsFromBottom,
    Priority = @Priority
WHERE Name = @Name; -- vagy WHERE Id = @Id