UPDATE FlaggedLicensePlates SET
    LicensePlate = @LicensePlate,
    DateReported = @DateReported,
    Description = @Description
WHERE Id = @Id;