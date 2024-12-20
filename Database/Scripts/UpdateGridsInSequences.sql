UPDATE GridsInSequences
SET 
    SequenceId = @SequenceId,
    GridId = @GridId,
    TimeToShow = @TimeToShow,
    Number = @Number,
    Checksum = @Checksum
WHERE Id = @Id;