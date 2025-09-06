UPDATE BarcodeScanOptions SET
    CustomIn = @CustomIn,
    CustomOut = @CustomOut,
    LcidIn = @LcidIn,
    LcidOut = @LcidOut,
    MaxDelay = @MaxDelay,
    SelectedComPort = @SelectedComPort,
    SerialScanner = @SerialScanner
WHERE Id = @Id;