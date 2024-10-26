namespace Mtf.Enums.Display
{
    public enum DescriptorType : byte
    {
        DisplayProductSerialNumber = 255,
        AlphanumericDataString = 254,
        DisplayRangeLimits = 253,
        DisplayProductName = 252,
        ColorPointData = 251,
        StandardTimingIdentifications = 250,
        DisplayColorManagementData = 249,
        CVT3ByteTimingCodes = 248,
        EstablishedTimingsIII = 247,
        DummyDescriptor = 16,
        Unknown = 0
    }
}
