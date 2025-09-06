UPDATE Grids SET
    Rows = @Rows,
    Columns = @Columns,
    PixelsFromRight = @PixelsFromRight,
    PixelsFromBottom = @PixelsFromBottom,
    Priority = @Priority,
    Name = @Name
WHERE Id = @Id;