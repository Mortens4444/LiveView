UPDATE GridsInSequences
SET 
    sequenceid = @SequenceId,
    gridid = @GridId,
    timetoshow = @TimeToShow,
    number = @Number,
    checksum = @Checksum
WHERE ID = @Id;