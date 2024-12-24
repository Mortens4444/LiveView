UPDATE GridsInSequences
SET 
    SequenceId = @SequenceId,
    GridId = @GridId,
    TimeToShow = @TimeToShow,
    Number = @Number
WHERE Id = @Id;