UPDATE MapObjects
SET 
    ActionType = @ActionType,
    ActionReferencedId = @ActionReferencedId,
    Comment = @Comment,
    X = @X,
    Y = @Y,
    Width = @Width,
    Height = @Height,
    Image = @Image
WHERE Id = @Id;
