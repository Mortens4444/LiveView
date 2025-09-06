UPDATE ActionObjects SET
    ActionReferencedId = @ActionReferencedId,
    ActionType = @ActionType,
    Comment = @Comment,
    Image = @Image,
    X = @X,
    Y = @Y,
    Width = @Width,
    Height = @Height
WHERE Id = @Id;