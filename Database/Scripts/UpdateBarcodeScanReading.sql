UPDATE BarcodeScanReadings SET
    Date = @Date,
    Value = @Value
WHERE Id = @Id;