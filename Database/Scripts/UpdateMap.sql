UPDATE Maps
SET 
    Name = @Name,
    Comment = @Comment,
    OriginalWidth = @OriginalWidth,
    OriginalHeight = @OriginalHeight,
    MapImage = @MapImage
WHERE Id = @Id;